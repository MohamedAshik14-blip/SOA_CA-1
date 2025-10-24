using TripPlannerApp.Models;
using WeatherApp.Models;

namespace WeatherApp.Services;
public interface ILocationService
{
    Task<TripLocation> GetUserLocationAsync();
    Task<TripLocation?> GetLocationByCityAsync(string city);
}
