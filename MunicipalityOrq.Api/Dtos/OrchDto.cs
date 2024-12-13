using MunicipalityOrq.Api.Models;
using System.Text.Json.Serialization;

namespace MunicipalityOrq.Api.Dtos;

public class OrchDto
{
    [JsonPropertyName("geografia")] public MunicipalityGeoDto GeoData { get; set; }
    [JsonPropertyName("clima")] public MunicipalityWeatherResponse WeatherData { get; set; }
}