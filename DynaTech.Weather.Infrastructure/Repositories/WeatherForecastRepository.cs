using AutoMapper;
using Dapper;
using DynaTech.Weather.Domain.Models;
using DynaTech.Weather.Infrastructure.Dtos;
using DynaTech.Weather.Infrastructure.Interfaces;
using DynaTech.Weather.Infrastructure.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Data;

namespace DynaTech.Weather.Infrastructure.Repositories
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;
        private readonly IMapper _mapper;
        private readonly ILogger<WeatherForecastRepository> _logger;
        private readonly DatabaseConfigurationSection _databaseConfiguration;

        public WeatherForecastRepository(
            IDatabaseConnectionFactory databaseConnectionFactory,
            IMapper mapper,
            ILogger<WeatherForecastRepository> logger,
            IOptions<DatabaseConfigurationSection> databaseConfiguration)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
            _mapper = mapper;
            _logger = logger;
            _databaseConfiguration = databaseConfiguration.Value;
        }

        public IEnumerable<WeatherForecast> GetWeatherForecasts()
        {
            try
            {
                using (var connection = _databaseConnectionFactory.GetWeatherDbConnection())
                {
                    var result = connection.Query<WeatherForecastDto>("SELECT * FROM dbo.WeatherForecasts");
                    var fromSource = _mapper.Map<IEnumerable<WeatherForecast>>(result);
                    return fromSource;
                }
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Error on {nameof(GetWeatherForecasts)} exception message: {ex.Message}");
                throw;
            }
        }

        public WeatherForecast GetWeatherForecastById(int weatherForecastId)
        {
            try
            {
                using (var connection = _databaseConnectionFactory.GetWeatherDbConnection())
                {
                    var result = connection.QueryFirst<WeatherForecastDto>($"SELECT * FROM dbo.Forecasts WHERE ForecastId = {weatherForecastId}");
                    var fromSource = _mapper.Map<WeatherForecast>(result);
                    return fromSource;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error on {nameof(GetWeatherForecastById)} exception message: {ex.Message}");
                throw;
            }
        }

        public async Task<WeatherForecast> AddWeatherForecast(AddWeatherForecastRequest request, CancellationToken cancellationToken)
        {
            try
            {
                string storedProcedure = _databaseConfiguration.StoredProcedureNames.WeatherForecastInsertStoredProcedureName;

                var parameters = new DynamicParameters();
                parameters.Add("@DateAndTime", request.DateAndTime, DbType.DateTime);
                parameters.Add("@TemperatureC", request.TemperatureC, DbType.Int32);
                parameters.Add("@Summary", request.Summary, DbType.String);

                using (var connection = _databaseConnectionFactory.GetWeatherDbConnection())
                {
                    var command = new CommandDefinition(
                        storedProcedure,
                        parameters,
                        commandType: CommandType.StoredProcedure,
                        commandTimeout: _databaseConnectionFactory.CommandTimeout,
                        cancellationToken: cancellationToken);

                    var result = await connection.QueryFirstOrDefaultAsync<WeatherForecastDto>(command);
                    var fromSource = _mapper.Map<WeatherForecast>(result);
                    return fromSource;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error on {nameof(AddWeatherForecast)} exception message: {ex.Message}");
                throw;
            }
        }
    }
}
