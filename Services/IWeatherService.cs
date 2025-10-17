using WeatherApp.Models;

namespace WeatherApp.Services;
public interface IWeatherService
{
    Task<WeatherInfo?> GetCurrentWeatherAsync(string city);
    Task<List<WeatherInfo>> GetForecastAsync(double lat, double lon);
}
