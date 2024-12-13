using AutoMapper;
using MunicipalityDemo.Api.Dtos;
using MunicipalityItem = MunicipalityDemo.Api.Entities.Municipality;

namespace MunicipalityDemo.Api.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MunicipalityItem, MunicipalityDto>().ReverseMap();
    }
}