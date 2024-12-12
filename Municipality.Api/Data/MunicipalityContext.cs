using Microsoft.EntityFrameworkCore;
using MuncipalityItem = Municipality.Api.Entities.Municipality;

namespace Municipality.Api.Data;

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
            Demonym = "Añoverano/Añoverana",
            Website = "http://anoverdetajo.es/",
        });
    }
}