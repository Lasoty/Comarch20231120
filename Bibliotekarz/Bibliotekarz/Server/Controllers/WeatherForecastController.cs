using Bibliotekarz.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Bibliotekarz.Server.Controllers
{

    [ApiController]
    [Route("[controller]")] // [GET] [POST] [PUT] [DELETE] https://localhost:8080/WeatherForecast/
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //[HttpGet("[action]")]
        [HttpGet()]
        //[HttpPost]
        //[HttpPut]
        //[HttpDelete]
        public IEnumerable<WeatherForecast> GetData()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
