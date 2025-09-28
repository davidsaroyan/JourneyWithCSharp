using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Services;
namespace WeatherApi.Controllers { 
    [ApiController]
    [Route("api/[controller]")] 
    public class WeatherController : ControllerBase 
    { 
        private readonly WeatherService _weatherService;
        public WeatherController(WeatherService weatherService) 
        { _weatherService = weatherService; } 
        [HttpGet("{city}")] 
        public async Task<IActionResult> GetWeather(string city) 
        { 
            var weather = await _weatherService.GetWeatherAsync(city);
            if (weather == null) return NotFound(new { message = "City not found" });
            return Ok(new 
            { 
                City = weather.Name,
                Temperature = weather.Main.Temp,
                Condition = weather.Weather[0].Description, 
                Wind = weather.Wind.Speed 
            }
            ); 
        }
        [HttpGet("save/{city}")]
        public async Task<IActionResult> GetWeatherFilePath(string city)
        {
            var weather = await _weatherService.SaveWeatherToFileAsync(city);
            if (weather == null) return NotFound(new { message = "City not found" });
            return Ok(weather);
        }
    } 
}
