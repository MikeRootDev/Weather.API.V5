using DynaTech.Weather.Infrastructure.Interfaces;
using DynaTech.Weather.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;

namespace DynaTech.Weather.Infrastructure.Repositories
{
    public class DatabaseConnectionFactory : IDatabaseConnectionFactory
    {
        private readonly DatabaseConfigurationSection _databaseConfiguration;

        public DatabaseConnectionFactory(IOptions<DatabaseConfigurationSection> databaseConfiguration)
        {
            _databaseConfiguration = databaseConfiguration.Value;
        }

        public int CommandTimeout => _databaseConfiguration.CommandTimeout;

        public int RetryAttempts => _databaseConfiguration.RetryAttempts;

        public IDbConnection GetWeatherDbConnection()
        {
            return new SqlConnection(_databaseConfiguration.ConnectionStrings.Cricut);
        }
    }
}
