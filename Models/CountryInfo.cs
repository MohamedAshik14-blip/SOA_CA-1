namespace WeatherApp.Models
{
    public class CountryInfo
    {
        public NameInfo Name { get; set; } = new();
        public List<string>? Capital { get; set; }
        public string Region { get; set; } = "";
        public long Population { get; set; }
        public Flags Flags { get; set; } = new();
        public string Cca2 { get; set; } = ""; 
    }

    public class NameInfo
    {
        public string Common { get; set; } = "";
        public string Official { get; set; } = "";
    }

    public class Flags
    {
        public string Svg { get; set; } = "";
        public string Png { get; set; } = "";
    }
}
