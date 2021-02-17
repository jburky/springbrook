using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Springbrook.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Springbrook.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherRegionController : ControllerBase
    {
        private readonly ILogger<WeatherRegionController> logger;
        private readonly WeatherService weatherService;

        public WeatherRegionController(ILogger<WeatherRegionController> logger, WeatherService weatherService)
        {
            this.logger = logger;
            this.weatherService = weatherService;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherRegion>> GetAsync(string stateAbbreviation)
        {
            return await weatherService.GetRegionsAsync(stateAbbreviation);
        }
    }
}
