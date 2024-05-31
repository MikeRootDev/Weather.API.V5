using DynaTech.Weather.Domain.Interfaces;
using DynaTech.Weather.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DynaTech.Weather.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForecastsController : ControllerBase
    {
        private readonly ILogger<ForecastsController> _logger;
        private readonly IWeatherForecastsService _forecastsService;

        public ForecastsController(
            ILogger<ForecastsController> logger,
            IWeatherForecastsService forecastsService)
        {
            _logger = logger;
            _forecastsService = forecastsService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            try
            {
                return _forecastsService.GetWeatherForecasts();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error on {nameof(Get)}, error message: {ex.Message}");
                throw;
            }
        }

        [HttpGet("{forecastId}")]
        public WeatherForecast Get(int weatherForecastId)
        {
            try
            {
                return _forecastsService.GetWeatherForecast(weatherForecastId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error on {nameof(Get)}, error message: {ex.Message}");
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddWeatherForecastRequest request, CancellationToken cancellationToken)
        {
            if (request is null || string.IsNullOrWhiteSpace(request.Summary) || !request.DateAndTime.HasValue 
                || request.DateAndTime.Value == DateTime.MinValue || !request.TemperatureC.HasValue) 
            {
                return BadRequest("Invalid request - some properties missing or with improper values.");
            }

            return Ok(await _forecastsService.AddWeatherForecast(request, cancellationToken));
        }
    }
}