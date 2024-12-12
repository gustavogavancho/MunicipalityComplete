using System.Text.Json.Serialization;

namespace MunicipalityGeo.Api.Dtos;

public class MunicipalityGeoDto
{
    [JsonPropertyName("municipioid")] public int Id { get; set; }
    [JsonPropertyName("longitud")] public double Longitude { get; set; }
    [JsonPropertyName("latitud")] public double Latitude { get; set; }
    [JsonPropertyName("altitud")] public int Altitude { get; set; }
}