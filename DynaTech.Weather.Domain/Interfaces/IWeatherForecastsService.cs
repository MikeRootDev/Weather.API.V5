using DynaTech.Weather.Domain.Models;

namespace DynaTech.Weather.Domain.Interfaces
{
    public interface IWeatherForecastsService
    {
        IEnumerable<WeatherForecast> GetWeatherForecasts();

        WeatherForecast GetWeatherForecast(int weatherForecastId);

        Task<WeatherForecast> AddWeatherForecast(AddWeatherForecastRequest request, CancellationToken cancellationToken);
    }
}
