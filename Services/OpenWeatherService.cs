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
