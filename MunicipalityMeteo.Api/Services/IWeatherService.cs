using MunicipalityMeteo.Api.Dtos;

namespace MunicipalityMeteo.Api.Services;

public interface IWeatherService
{
    ValueTask<WeatherInfoDto> GetMunicipaliyWeatherDataAsync(int municipalityId);
}