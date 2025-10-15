namespace TripPlannerApp.Models;
public class TripLocation
{
    public string City { get; set; } = "Unknown";
    public string Country { get; set; } = "Unknown";
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
