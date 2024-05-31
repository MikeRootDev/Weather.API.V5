namespace DynaTech.Weather.Infrastructure.Dtos
{
    public class WeatherForecastDto
    {
        public int WeatherForecastId { get; set; }
        public DateTime DateAndTime { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }
    }
}
