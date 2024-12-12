namespace Municipality.Api.Repository;
using MunicipalityItem = Municipality.Api.Entities.Municipality;

public interface IMunicipalityRepository
{
    ValueTask<MunicipalityItem> GetMunicipalityById(int municipalityId);
}