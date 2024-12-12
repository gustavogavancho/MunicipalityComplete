using System.Text.Json.Serialization;

namespace Municipality.Api.Dtos;

public class MunicipalityDto
{
    [JsonPropertyName("municipioid")] public int Id { get; set; }
    [JsonPropertyName("gentilicio")] public string Demonym { get; set; }
    [JsonPropertyName("sitioweb")] public string Website { get; set; }
}