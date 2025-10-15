using WeatherApp.Models;

namespace WeatherApp.Services;
public interface ICountryService
{
    Task<CountryInfo?> GetCountryInfoAsync(string countryName);
}
