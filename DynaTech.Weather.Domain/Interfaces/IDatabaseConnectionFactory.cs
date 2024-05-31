using System.Data;

namespace DynaTech.Weather.Infrastructure.Interfaces
{
    public interface IDatabaseConnectionFactory
    {
        int CommandTimeout { get; }
        int RetryAttempts { get; }
        IDbConnection GetWeatherDbConnection();
    }
}
