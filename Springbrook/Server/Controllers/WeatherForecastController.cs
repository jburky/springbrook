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
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> logger;
        private readonly WeatherService weatherService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherService weatherService)
        {
            this.logger = logger;
            this.weatherService = weatherService;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> GetAsync(string id)
        {
            return await weatherService.GetForecastAsync(id);
        }
    }
}
