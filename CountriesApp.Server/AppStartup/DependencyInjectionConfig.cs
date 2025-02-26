using CountriesApp.Server.BL;
using CountriesApp.Server.Domain.Dto;
using CountriesApp.Server.Domain.Interfaces.Repo;
using CountriesApp.Server.Domain.Variables;
using CountriesApp.Server.Repository;

namespace CountriesApp.Server.AppStartup;

internal static class DependencyInjectionConfig
{
    internal static void AddDependencyInjectionConfig(this IServiceCollection services, IConfiguration config)
    {
        #region Repository
        services.AddHttpClient<IRepository<Country>, CountryRestRepository>(client =>
        {
            client.BaseAddress = new Uri(config[AppSettingsKeys.COUNTRIES_API_V3] ?? throw new Exception("RestCountries Url not set"));
        });

        #endregion

        #region Application BL

        services.AddScoped(typeof(CountriesBL));

        #endregion

        


    }
}