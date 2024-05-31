namespace DynaTech.Weather.Domain.Models
{
    public class WeatherForecast
    {
        public int WeatherForecastId { get; set; }

        public DateTime DateAndTIme { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF { get; set; }

        public string Summary { get; set; }
    }
}