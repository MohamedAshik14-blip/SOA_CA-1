using System.Net.Http.Json;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class OpenWeatherService : IWeatherService
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;

        public OpenWeatherService(HttpClient http, string apiKey)
        {
            _http = http;
            _apiKey = apiKey;
        }
 public async Task<WeatherInfo?> GetCurrentWeatherAsync(string city)
        {
            if (string.IsNullOrWhiteSpace(city)) return null;
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={Uri.EscapeDataString(city)}&appid={_apiKey}&units=metric";

            try
            {
                var resp = await _http.GetFromJsonAsync<OpenWeatherCurrent>(url);
                if (resp == null) return null;

                var wt = resp.Weather.FirstOrDefault()?.Main ?? "";
                var type = wt switch
                {
                    "Clear" => WeatherType.Sunny,
                    "Clouds" => WeatherType.Cloudy,
                    "Rain" => WeatherType.Rainy,
                    "Snow" => WeatherType.Snowy,
                    _ => WeatherType.Unknown
                };

                return new WeatherInfo
                {
                    Date = DateTimeOffset.FromUnixTimeSeconds(resp.Dt).DateTime,
                    TemperatureC = resp.Main.Temp,
                    Type = type,
                    Description = resp.Weather.FirstOrDefault()?.Description ?? "",
                    Latitude = resp.Coord.Lat,
                    Longitude = resp.Coord.Lon
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Weather API error: {ex.Message}");
                return null;
            }
        }
          public async Task<List<WeatherInfo>> GetForecastAsync(double lat, double lon)
        {
            var list = new List<WeatherInfo>();
            if (lat == 0 && lon == 0) return list;

            var url = $"https://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&units=metric&appid={_apiKey}";

            try
            {
                var resp = await _http.GetFromJsonAsync<ForecastResponse>(url);
                if (resp?.List == null) return list;

                var dailyGroups = resp.List
                    .GroupBy(x => DateTimeOffset.FromUnixTimeSeconds(x.Dt).Date)
                    .Take(3);

                foreach (var g in dailyGroups)
                {
                    var first = g.First();
                    var wt = first.Weather.FirstOrDefault()?.Main ?? "";
                    var type = wt switch
                    {
                        "Clear" => WeatherType.Sunny,
                        "Clouds" => WeatherType.Cloudy,
                        "Rain" => WeatherType.Rainy,
                        "Snow" => WeatherType.Snowy,
                        _ => WeatherType.Unknown
                    };

                    list.Add(new WeatherInfo
                    {
                        Date = g.Key,
                        TemperatureC = first.Main.Temp,
                        Type = type,
                        Description = first.Weather.FirstOrDefault()?.Description ?? ""
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Forecast API error: {ex.Message}");
            }

            return list;
        }
    }


         public class OpenWeatherCurrent
    {
        public Coord Coord { get; set; } = new();
        public Weather[] Weather { get; set; } = Array.Empty<Weather>();
        public Main Main { get; set; } = new();
        public long Dt { get; set; }
    }

