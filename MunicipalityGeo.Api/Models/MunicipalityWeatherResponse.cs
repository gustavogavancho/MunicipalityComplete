using System.Text.Json.Serialization;

namespace MunicipalityGeo.Api.Models;

public class MunicipalityWeatherResponse
{
    [JsonPropertyName("ID_REL")] public string Id { get; set; }
    [JsonPropertyName("LONGITUD_ETRS89_REGCAN95")] public double Longitude { get; set; }
    [JsonPropertyName("LATITUD_ETRS89_REGCAN95")] public double Latitude { get; set; }
    [JsonPropertyName("ALTITUD")] public int Altitude { get; set; }
}