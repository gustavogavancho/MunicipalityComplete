using AutoMapper;
using MunicipalityMeteo.Api.Dtos;
using MunicipalityMeteo.Api.Models;

namespace MunicipalityMeteo.Api.Profiles;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
        CreateMap<WeatherResponse, WeatherInfoDto>().ReverseMap();
        CreateMap<TemperaturasResponse, TemperaturesDto>().ReverseMap();
    }
}