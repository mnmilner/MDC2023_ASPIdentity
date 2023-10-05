using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MDCUnitsConverterAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // you can uncomment this attribute if you enable roles (programs.cs)
    // and use the identity.http to create the role and add your user
    //[Authorize(Roles = "DemoUsers")]  
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

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            //example just to show you can get the user claim information in your code
            var nameClaim = this.HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault();
            string name = nameClaim != null ? nameClaim.Value : "Unknown";

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                UserName = name,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
