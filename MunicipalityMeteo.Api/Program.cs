using MunicipalityMeteo.Api.Profiles;
using MunicipalityMeteo.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IWeatherService, WeatherService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("/{municipalityId:int}/meteo", async (int municipalityId, IWeatherService weatherService) =>
{
    var municipalityGeo = await weatherService.GetMunicipaliyWeatherDataAsync(municipalityId);

    return Results.Ok(municipalityGeo);
})
.WithName("GetMeteorologicInfoByMunicaplityId")
.WithOpenApi();

app.Run();