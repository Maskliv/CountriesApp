using CountriesApp.Server.Domain.Dto;
using CountriesApp.Server.Domain.Interfaces.Repo;

namespace CountriesApp.Server.BL;

public class CountriesBL(IRepository<Country> _countryRepo)
{
    private string[] _defaultFields = ["name", "region", "languages", "population", "flags"];
    public async Task<IEnumerable<Country>> GetAll()
    {
       return await _countryRepo.Get(filter: $"/all?fields={string.Join(',',_defaultFields)}");

    }
    public async Task<IEnumerable<Country>> GetByAttribute(string attribute, string value)
    {
        return await _countryRepo.Get($"/{attribute}/{value}?fields={string.Join(',', _defaultFields)}");
    }
}
