using MunicipalityOrq.Api.Dtos;
using MunicipalityOrq.Api.Models;
using System.Text.Json;

namespace MunicipalityOrq.Api.Services;

public class WeatherService : IWeatherService
{
    private readonly HttpClient httpClient;

    public WeatherService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async ValueTask<OrchDto> GetMunicipaliyDataAsync(int municipalityId)
    {
        var orchData = new OrchDto();
        orchData.GeoData = await GetGeo(municipalityId);
        orchData.WeatherData = await GetWeather(municipalityId);

        return orchData;
    }

    private async ValueTask<MunicipalityWeatherResponse> GetWeather(int municipalityId) 
    {
        try
        {
            var url = $"https://localhost:5002/{municipalityId}/meteo";

            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode) throw new Exception($"Error retrieving weather data: {response.StatusCode}");

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var weatherData = JsonSerializer.Deserialize<MunicipalityWeatherResponse>(jsonResponse);

            return weatherData;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while consuming an external API: {ex.Message}");
        }
    }

    private async ValueTask<MunicipalityGeoDto> GetGeo(int municipalityId)
    {
        try
        {
            var url = $"https://localhost:5001/{municipalityId}/geo";

            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode) throw new Exception($"Error retrieving weather data: {response.StatusCode}");

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var weatherData = JsonSerializer.Deserialize<MunicipalityGeoDto>(jsonResponse);

            return weatherData;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while consuming an external API: {ex.Message}");
        }
    }
}