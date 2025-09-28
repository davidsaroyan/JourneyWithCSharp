using System.Text.Json;

namespace WeatherAPI.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "d95d6f5ebad1bd7d71325806e4569d58";
        private readonly string _folderPath;
        
        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _folderPath = Path.Combine(Directory.GetCurrentDirectory(), "WeatherData"); 
            Directory.CreateDirectory(_folderPath);
        }
        public async Task<WeatherResponse> GetWeatherAsync(string city)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric";

            return await _httpClient.GetFromJsonAsync<WeatherResponse>(url);
        }
        public async Task<string> SaveWeatherToFileAsync(string city)
        {
            var weather = await this.GetWeatherAsync(city);
            if (weather == null)
                return null;

            var json = JsonSerializer.Serialize(weather, new JsonSerializerOptions { WriteIndented = true });
            var filePath = Path.Combine(_folderPath, $"{city}_{DateTime.UtcNow:yyyyMMdd_HHmmss}.json");

            await File.WriteAllTextAsync(filePath, json);

            return filePath;
        }
    }
    public class WeatherRequest 
    {
        public string City { get; set; }
    }
    public class WeatherResponse 
    {
        public MainInfo Main { get; set; }
        public WindInfo Wind { get; set; }
        public WeatherInfo[] Weather { get; set; }    
        public string Name { get; set; }
    }
    public class WeatherInfo
    {
        public string Description { get; set; }
    }
    public class MainInfo 
    {
        public double Temp { get; set; } 
    }
    public class WindInfo 
    {
        public double Speed { get; set; }
    }
}
