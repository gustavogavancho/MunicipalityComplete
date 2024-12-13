using MunicipalityOrq.Api.Dtos;

namespace MunicipalityOrq.Api.Services;

public interface IWeatherService
{
    ValueTask<OrchDto> GetMunicipaliyDataAsync(int municipalityId);
}