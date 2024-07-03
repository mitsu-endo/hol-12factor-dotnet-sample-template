namespace TFApp.Models;

public class Weather
{
    public string temperature { get; set; }
    public string wind { get; set; }
    public string description { get; set; }
    public Forecast[] forecast { get; set; }
}

public class Forecast
{
    public string day { get; set; }
    public string temperature { get; set; }
    public string wind { get; set; }
}
