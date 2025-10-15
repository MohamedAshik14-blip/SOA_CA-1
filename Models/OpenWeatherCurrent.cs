namespace WeatherApp.Models;
public class OpenWeatherCurrent
{
    public MainInfo Main { get; set; } = new();
    public WeatherShort[] Weather { get; set; } = new WeatherShort[0];
    public long Dt { get; set; }
    public string Name { get; set; } = "";
}
public class MainInfo { public double Temp { get; set; } }
public class WeatherShort { public string Main { get; set; } = ""; public string Description { get; set; } = ""; }

public class OpenWeatherOneCall
{
    public Daily[] daily { get; set; } = new Daily[0];
}
public class Daily
{
    public long dt { get; set; }
    public Temp temp { get; set; } = new Temp();
    public WeatherShort[] weather { get; set; } = new WeatherShort[0];
}
public class Temp { public double day { get; set; } }
