using DynaTech.Weather.Domain.Models;

namespace DynaTech.Weather.Infrastructure.Interfaces
{
    public interface IWeatherForecastRepository
    {
        IEnumerable<WeatherForecast> GetWeatherForecasts();

        WeatherForecast GetWeatherForecastById(int weatherForecastId);

        Task<WeatherForecast> AddWeatherForecast(AddWeatherForecastRequest request, CancellationToken cancellationToken);
    }
}
