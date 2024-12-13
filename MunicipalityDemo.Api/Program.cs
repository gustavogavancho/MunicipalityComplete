using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MunicipalityDemo.Api.Data;
using MunicipalityDemo.Api.Dtos;
using MunicipalityDemo.Api.Profiles;
using MunicipalityDemo.Api.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<MunicipalityContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("MunicipalityDB")));
builder.Services.AddScoped<IMunicipalityRepository, MunicipalityRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MunicipalityContext>();
    await dbContext.Database.EnsureCreatedAsync();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("/{municipalityId:int}/demo", async (int municipalityId, IMunicipalityRepository municipalityRepository, IMapper mapper) =>
{
    var municipality = await municipalityRepository.GetMunicipalityById(municipalityId);

    if (municipality == null) return Results.NotFound($"Municipality with id {municipalityId} was not found.");

    var municipalityResponse = mapper.Map<MunicipalityDto>(municipality);

    return Results.Ok(municipalityResponse);
})
.WithName("GetDemographicInfoById")
.WithOpenApi();

app.Run();
