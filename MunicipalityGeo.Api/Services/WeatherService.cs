using AutoMapper;
using MunicipalityGeo.Api.Dtos;
using MunicipalityGeo.Api.Models;
using System.Text.Json;

namespace MunicipalityGeo.Api.Services;

public class WeatherService : IWeatherService
{
    private readonly HttpClient httpClient;
    private readonly IMapper mapper;

    public WeatherService(HttpClient httpClient, IMapper mapper)
    {
        this.httpClient = httpClient;
        this.mapper = mapper;
    }

    public async ValueTask<MunicipalityGeoDto> GetMunicipaliyWeatherDataAsync(int municipalityId)
    {
        try
        {
            var url = $"https://www.el-tiempo.net/api/json/v2/provincias/45/municipios/{municipalityId}";

            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode) throw new Exception($"Error retrieving weather data: {response.StatusCode}");

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var weatherData = JsonSerializer.Deserialize<MunicipalityResponse>(jsonResponse);
            var municipalityWeather = mapper.Map<MunicipalityGeoDto>(weatherData.Municipality);

            RemoveFirstDigit(municipalityWeather.Id);

            return municipalityWeather;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while consuming an external API: {ex.Message}");
        }
    }

    private void RemoveFirstDigit(int number)
    {
        string numberStr = number.ToString();
        string resultStr = numberStr.Substring(1);

        int.Parse(resultStr);
    }
}