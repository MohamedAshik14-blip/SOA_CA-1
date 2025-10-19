using System.Net.Http.Json;
using System.Text.Json;
using WeatherApp.Models;

namespace WeatherApp.Services;

public class IpApiResponse
{
    public string? city { get; set; }
    public string? country { get; set; }
    public double lat { get; set; }
    public double lon { get; set; }
}
Public class GeolocationService : ILocationService
{
    private readonly HttpClient _http;
    private readonly string _openWeatherApiKey;

    public GeolocationService(HttpClient http, IConfiguration config)
    {
        _http = http;
        _openWeatherApiKey = config["OpenWeatherApiKey"] ?? "";
    }

    public async Task<TripLocation> GetUserLocationAsync()
    {
      
        var resp = await _http.GetFromJsonAsync<IpApiResponse>("http://ip-api.com/json/");
        return new TripLocation
        {
            City = resp?.city ?? "Unknown",
            Country = resp?.country ?? "Unknown",
            Latitude = resp?.lat ?? 0,
            Longitude = resp?.lon ?? 0
        };
    }

     public async Task<TripLocation?> GetLocationByCityAsync(string city)
    {
        if (string.IsNullOrWhiteSpace(city)) return null;

        var url = $"https://api.openweathermap.org/data/2.5/weather?q={Uri.EscapeDataString(city)}&appid={_openWeatherApiKey}";
        var data = await _http.GetFromJsonAsync<JsonElement>(url);

        if (!data.TryGetProperty("coord", out var coord))
            return null;

        return new TripLocation
        {
            City = city,
            Latitude = coord.GetProperty("lat").GetDouble(),
            Longitude = coord.GetProperty("lon").GetDouble(),
            Country = data.GetProperty("sys").GetProperty("country").GetString() ?? "Unknown"
        };
    }
}

