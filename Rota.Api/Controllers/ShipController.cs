using Microsoft.AspNetCore.Mvc;

namespace Rota.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShipController : ControllerBase
    {
        public ShipController(ILogger<ShipController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Ship> Get()
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
