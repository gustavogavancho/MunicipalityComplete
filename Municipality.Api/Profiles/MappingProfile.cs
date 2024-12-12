using AutoMapper;
using Municipality.Api.Dtos;
using MunicipalityItem = Municipality.Api.Entities.Municipality;

namespace Municipality.Api.Profiles;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
        CreateMap<MunicipalityItem, MunicipalityDto>().ReverseMap();
    }
}