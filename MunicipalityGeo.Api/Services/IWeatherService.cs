using MunicipalityGeo.Api.Dtos;
using MunicipalityGeo.Api.Models;

namespace MunicipalityGeo.Api.Services;

public interface IWeatherService
{
    ValueTask<MunicipalityGeoDto> GetMunicipaliyWeatherDataAsync(int municipalityId);
}