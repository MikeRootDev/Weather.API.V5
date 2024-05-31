namespace DynaTech.Weather.Infrastructure.Settings
{
    public class DatabaseConfigurationSection
    {
        public int CommandTimeout { get; set; } = 30;
        public int RetryAttempts { get; set; } = 3;
        public ConnectionStringsSection ConnectionStrings { get; set; }
        public StoredProcedureNames StoredProcedureNames { get; set; }
    }

    public class ConnectionStringsSection
    {
        public string Cricut { get; set; }
    }

    public class StoredProcedureNames
    {
        public string WeatherForecastInsertStoredProcedureName { get; set; }
    }
}
