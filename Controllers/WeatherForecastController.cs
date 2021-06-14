using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherWithVue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
      {
            "Солнечно", "Облачно", "Небольшой дождь", "Сильный дождь", "Гроза"
        };

        private static readonly string[] WindDirections = new[]
        {
            "северный", "южный", "западный", "восточный", "северо-западный", "северо-восточный", "юго-западный", "юго-восточный"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 10).Select(index => new WeatherForecast
            {
                Date = DateTime.Today.AddDays(index),
                TemperatureMin = rng.Next(1, 25),
                TemperatureMax = rng.Next(2, 35),
                Pressure = rng.Next(710, 770),
                Humidity = rng.Next(20, 90),
                WindSpeed = rng.Next(0, 8),
                WindDirection = WindDirections[rng.Next(WindDirections.Length)],
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
