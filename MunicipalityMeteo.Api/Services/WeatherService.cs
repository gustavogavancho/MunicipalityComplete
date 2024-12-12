using AutoMapper;
using MunicipalityMeteo.Api.Dtos;
using MunicipalityMeteo.Api.Models;
using System.Text.Json;

namespace MunicipalityMeteo.Api.Services;

public class WeatherService : IWeatherService
{
    private readonly HttpClient httpClient;
    private readonly IMapper mapper;

    public WeatherService(HttpClient httpClient, IMapper mapper)
    {
        this.httpClient = httpClient;
        this.mapper = mapper;
    }

    public async ValueTask<WeatherInfoDto> GetMunicipaliyWeatherDataAsync(int municipalityId)
    {
        try
        {
            var url = $"https://www.el-tiempo.net/api/json/v2/provincias/45/municipios/{municipalityId}";

            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode) throw new Exception($"Error retrieving weather data: {response.StatusCode}");

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var weatherData = JsonSerializer.Deserialize<WeatherResponse>(jsonResponse);

            var municipalityWeather = mapper.Map<WeatherInfoDto>(weatherData);

            municipalityWeather.Id = municipalityId;

            return municipalityWeather;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while consuming an external API: {ex.Message}");
        }
    }
}