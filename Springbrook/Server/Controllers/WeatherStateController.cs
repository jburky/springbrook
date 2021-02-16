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
        private readonly ILogger<WeatherStateController> _logger;
        private readonly WeatherService _weatherService;

        public WeatherStateController(ILogger<WeatherStateController> logger, WeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherState>> Get()
        {
            return await _weatherService.GetStates();
        }
    }
}
