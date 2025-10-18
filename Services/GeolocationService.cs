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
