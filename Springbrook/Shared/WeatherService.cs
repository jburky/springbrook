using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Springbrook.Shared
{
    public class WeatherService
    {
        private const string BASE_URL = "https://api.weather.gov";
        private const string CACHE_FILE_STATES = "Cache\\states.json";
        private IEnumerable<WeatherState> states;

        private async Task<IRestResponse> RequestAsync(string resource, Method method = Method.GET)
        {
            var client = new RestClient(BASE_URL);
            client.Timeout = 1000 * 60;
            client.ReadWriteTimeout = 1000 * 60;
            var request = new RestRequest(resource, method);
            request.RequestFormat = DataFormat.Json;
            var result = await client.ExecuteAsync(request);
            if (result.ErrorException != null)
                throw new Exception("The National Weather Service didn't respond, try again!", result.ErrorException);
            return result;
        }

        public async Task<IEnumerable<WeatherState>> GetStatesAsync()
        {
            if (states == null)
            {
                var data = await File.ReadAllTextAsync(CACHE_FILE_STATES);
                var json = JArray.Parse(data);
                states = json.Select(x =>
                    new WeatherState
                    {
                        Name = x["name"]?.ToString(),
                        Abbreviation = x["abbreviation"]?.ToString()
                    });
            }

            return states;
        }

        public async Task<IEnumerable<WeatherRegion>> GetRegionsAsync(string stateAbbreviation)
        {
            var response = await RequestAsync($"/zones/public?area={stateAbbreviation}", Method.GET);

            var json = JObject.Parse(response.Content);
            var props = json.SelectTokens("$..properties");
            return props
                .Select(x =>
                    new WeatherRegion
                    {
                        ID = x["id"]?.ToString(),
                        Name = x["name"]?.ToString()
                    })
                .OrderBy(x => x.Name);
        }

        public async Task<IEnumerable<WeatherForecast>> GetForecastAsync(string id)
        {
            var response = await RequestAsync($"/zones/public/{id}/forecast", Method.GET);

            var json = JObject.Parse(response.Content);
            var periods = (JArray)json.SelectToken("$..periods");

            return periods
                .Select(x =>
                    new WeatherForecast()
                    {
                        Name = x["name"]?.ToString(),
                        Description = x["detailedForecast"]?.ToString()
                    });
        }
    }
}
