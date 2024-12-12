using System.Text.Json.Serialization;

namespace MunicipalityMeteo.Api.Models;

public class WeatherResponse
{
    [JsonPropertyName("temperatura_actual")] public string Temperature { get; set; }
    [JsonPropertyName("temperaturas")] public TemperaturasResponse Temperatures { get; set; }
    [JsonPropertyName("humedad")] public string Humidity { get; set; }
    [JsonPropertyName("viento")] public string Wind { get; set; }
    [JsonPropertyName("precipitacion")] public string Precipitation { get; set; }
    [JsonPropertyName("lluvia")] public string Rain { get; set; }
}

public class TemperaturasResponse
{
    [JsonPropertyName("min")] public string Min { get; set; }
    [JsonPropertyName("max")] public string Max { get; set; }
}