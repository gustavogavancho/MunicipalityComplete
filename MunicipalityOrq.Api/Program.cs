using MunicipalityOrq.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IWeatherService, WeatherService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("/{municipalityId:int}/geo/meteo", async (int municipalityId, IWeatherService weatherService) =>
{
    var municipalityGeo = await weatherService.GetMunicipaliyDataAsync(municipalityId);

    return Results.Ok(municipalityGeo);
})
.WithName("GetGeoAndWeatherInfoByMunicipalityId")
.WithOpenApi();

app.Run();