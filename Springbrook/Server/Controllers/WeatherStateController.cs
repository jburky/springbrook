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
    public class WeatherStateController : ControllerBase
    {
        private readonly ILogger<WeatherStateController> logger;
        private readonly WeatherService weatherService;

        public WeatherStateController(ILogger<WeatherStateController> logger, WeatherService weatherService)
        {
            this.logger = logger;
            this.weatherService = weatherService;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherState>> GetAsync()
        {
            return await weatherService.GetStatesAsync();
        }
    }
}
