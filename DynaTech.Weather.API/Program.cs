using DynaTech.Weather.Domain;
using DynaTech.Weather.Domain.Interfaces;
using DynaTech.Weather.Infrastructure.Interfaces;
using DynaTech.Weather.Infrastructure.Profiles;
using DynaTech.Weather.Infrastructure.Repositories;
using DynaTech.Weather.Infrastructure.Settings;

namespace DynaTech.Weather.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<DatabaseConfigurationSection>(builder.Configuration.GetSection("DatabaseConfiguration"));

            builder.Services.AddScoped<IWeatherForecastsService, WeatherForecastsService>();
            builder.Services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
            builder.Services.AddSingleton<IDatabaseConnectionFactory, DatabaseConnectionFactory>();

            List<Type> scanTypes = new List<Type> { typeof(InfrastructureProfile) };
            builder.Services.AddAutoMapper(options =>
            {
                options.AllowNullCollections = true;
            }, scanTypes);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}