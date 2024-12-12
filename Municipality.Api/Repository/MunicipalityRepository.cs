using Microsoft.EntityFrameworkCore;
using Municipality.Api.Data;
using MunicpalityItem = Municipality.Api.Entities.Municipality;

namespace Municipality.Api.Repository;

public class MunicipalityRepository : IMunicipalityRepository
{
    private readonly MunicipalityContext context;

    public MunicipalityRepository(MunicipalityContext context)
    {
        this.context = context;
    }

    public async ValueTask<MunicpalityItem> GetMunicipalityById(int id)
    {
        var municipality = await context.Municipalities.FirstOrDefaultAsync(x => x.Id == id);

        return municipality;
    }
}