using System.Text.Json.Serialization;

namespace MunicipalityGeo.Api.Models;

public class MunicipalityResponse
{
    [JsonPropertyName("municipio")] public MunicipalityWeatherResponse Municipality { get; set; }
}