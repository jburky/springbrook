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
        private readonly ILogger<WeatherRegionController> _logger;
        private readonly WeatherService _weatherService;

        public WeatherRegionController(ILogger<WeatherRegionController> logger, WeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherRegion>> Get(string stateAbbreviation)
        {
            return await _weatherService.GetRegions(stateAbbreviation);
        }
    }
}
