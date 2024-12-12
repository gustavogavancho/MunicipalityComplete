using AutoMapper;
using MunicipalityGeo.Api.Dtos;
using MunicipalityGeo.Api.Models;

namespace MunicipalityGeo.Api.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MunicipalityWeatherResponse, MunicipalityGeoDto>().ReverseMap();
    }
}