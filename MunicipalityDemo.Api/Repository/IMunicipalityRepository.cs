using MunicipalityItem = MunicipalityDemo.Api.Entities.Municipality;

namespace MunicipalityDemo.Api.Repository;

public interface IMunicipalityRepository
{
    ValueTask<MunicipalityItem> GetMunicipalityById(int municipalityId);
}