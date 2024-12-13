using Microsoft.EntityFrameworkCore;
using MuncipalityItem = MunicipalityDemo.Api.Entities.Municipality;

namespace MunicipalityDemo.Api.Data;

public class MunicipalityContext : DbContext
{
    public DbSet<Entities.Municipality> Municipalities { get; set; }

    public MunicipalityContext(DbContextOptions<MunicipalityContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MuncipalityItem>().HasData(new MuncipalityItem
        {
            Id = 45014,
            Mayor = "Rodrigo Moreno Contreras",
            Party = "Partido Socialista Obrero Español (PSOE)",
            Population = 5209,
        });
    }
}