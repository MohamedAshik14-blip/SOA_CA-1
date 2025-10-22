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

    
