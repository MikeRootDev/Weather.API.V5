using AutoMapper;
using DynaTech.Weather.Domain.Models;
using DynaTech.Weather.Infrastructure.Dtos;

namespace DynaTech.Weather.Infrastructure.Profiles
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<WeatherForecastDto, WeatherForecast>().ReverseMap();
        }
    }
}
