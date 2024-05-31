using DynaTech.Weather.Domain.Interfaces;
using DynaTech.Weather.Domain.Models;
using DynaTech.Weather.Infrastructure.Interfaces;

namespace DynaTech.Weather.Domain
{
    public class WeatherForecastsService : IWeatherForecastsService
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastsService(IWeatherForecastRepository forecastRepository) 
        { 
            _weatherForecastRepository = forecastRepository;
        }

        public IEnumerable<WeatherForecast> GetWeatherForecasts()
        {
            return _weatherForecastRepository.GetWeatherForecasts();
        }

        public WeatherForecast GetWeatherForecast(int weatherForecastId)
        {
            return _weatherForecastRepository.GetWeatherForecastById(weatherForecastId);
        }

        public async Task<WeatherForecast> AddWeatherForecast(AddWeatherForecastRequest request, CancellationToken cancellationToken) 
        {
            return await _weatherForecastRepository.AddWeatherForecast(request, cancellationToken);
        }
    }
}
