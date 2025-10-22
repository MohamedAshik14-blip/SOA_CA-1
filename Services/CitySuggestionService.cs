using System.Net.Http.Json;

namespace WeatherApp.Services
{
    
    public class GeoCityDto
    {
        public string Name { get; set; } = "";
        public string AdminName1 { get; set; } = "";
        public string CountryName { get; set; } = "";
        public string CountryCode { get; set; } = "";
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long Population { get; set; }
    }

    public class CitySuggestionService
    {
        private readonly HttpClient _http;
        private const string GeoNamesUsername = "ashik_001"; 

        public CitySuggestionService(HttpClient http)
        {
            _http = http;
        }

       public async Task<List<GeoCityDto>> GetTopCitiesAsync(string countryCode, int max = 10)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(countryCode)) return new();

                var url = $"http://api.geonames.org/searchJSON?country={Uri.EscapeDataString(countryCode)}&featureClass=P&maxRows=100&orderby=population&username={GeoNamesUsername}";
                var response = await _http.GetFromJsonAsync<GeoNamesResponse>(url);
                if (response?.Geonames == null) return new();

                var mapped = response.Geonames
                    .Where(g => TryParseDouble(g.lat, out _) && TryParseDouble(g.lng, out _))
                    .Select(g => new GeoCityDto
                    {
                        Name = g.name ?? "",
                        AdminName1 = g.adminName1 ?? "",
                        CountryName = g.countryName ?? "",
                        CountryCode = g.countryCode ?? "",
                        Latitude = double.TryParse(g.lat, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var la) ? la : 0,
                        Longitude = double.TryParse(g.lng, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var lo) ? lo : 0,
                        Population = g.population
                    })
                    .Where(x => x.Population > 0)
                    .OrderByDescending(x => x.Population)
                    .Take(max)
                    .ToList();

                return mapped;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GeoNames API error: {ex.Message}");
                return new List<GeoCityDto>();
            }
        }

