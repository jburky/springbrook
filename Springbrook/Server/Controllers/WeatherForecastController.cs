﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherService _weatherService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get(string id)
        {
            return await _weatherService.GetForecast(id);
        }
    }
}
