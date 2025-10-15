using System.Net.Http.Json;
using WeatherApp.Models;

namespace WeatherApp.Services;

public class CountryService : ICountryService
{
    private readonly HttpClient _http;
    public CountryService(HttpClient http) { _http = http; }

    public async Task<CountryInfo?> GetCountryInfoAsync(string countryName)
    {
        if (string.IsNullOrWhiteSpace(countryName)) return null;
        try
        {
           
            var url = $"https://restcountries.com/v3.1/name/{Uri.EscapeDataString(countryName)}";
            var arr = await _http.GetFromJsonAsync<CountryInfo[]>(url);
            return arr?.FirstOrDefault();
        }
        catch
        {
            return null;
        }
    }
}
