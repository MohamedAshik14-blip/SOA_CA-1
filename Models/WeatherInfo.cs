namespace WeatherApp.Models;
public enum WeatherType { Sunny, Cloudy, Rainy, Snowy, Unknown }

public class WeatherInfo
{
    public DateTime Date { get; set; }
    public double TemperatureC { get; set; }
    public WeatherType Type { get; set; }
    public string Description { get; set; } = "";
    
  
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
