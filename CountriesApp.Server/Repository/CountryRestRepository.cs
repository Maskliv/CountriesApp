using CountriesApp.Server.Domain.Dto;
using CountriesApp.Server.Domain.Exceptions;
using CountriesApp.Server.Domain.Interfaces.Repo;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;
using System.Net;

namespace CountriesApp.Server.Repository
{
    public class CountryRestRepository(HttpClient _httpClient) : IRepository<Country>
    {

        public async Task<IEnumerable<Country>> Get(string? filter = "", Func<IQueryable<Country>, IOrderedQueryable<Country>>? orderBy = null, Tuple<int, int>? offset = null, string includeProperties = "")
        {
            var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}{filter}");
            var content = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == HttpStatusCode.NotFound) throw new NotFoundException("No results");
            else if (response.StatusCode == HttpStatusCode.InternalServerError) throw new Exception("ResCountries Api not responding");
            else if (response.StatusCode != HttpStatusCode.OK) throw new BadRequestException($"RestCountries bad response. StatusCode: {response.StatusCode} -> {content}");
                        
            var countriesJson = JToken.Parse(content);
            var countries = DeserializeCountry(countriesJson);

            return countries;


        }

        private List<Country> DeserializeCountry(JToken jsonObj)
        {
            var res = new List<Country>();
            JArray array = (JArray)jsonObj;
            foreach (var jsonCountry in array)
            {
                var country = new Country();
               
                country.Name = new NameInfo
                {
                    Common = jsonCountry["name"]?["common"]?.ToString() ?? string.Empty,
                    Official = jsonCountry["name"]?["official"]?.ToString() ?? string.Empty,
                };

                var nativeNameAb = jsonCountry["name"]?["nativeName"]?
                    .ToObject<JObject>()?
                    .Properties()
                    .Select(p => p.Name)
                    .FirstOrDefault() ?? string.Empty;
                if (nativeNameAb != null) country.Name.NativeName = new Translation
                {
                    Abreviation = nativeNameAb,
                    Official = jsonCountry["name"]?["nativeName"]?[nativeNameAb]?["official"]?.ToString(),
                    Common = jsonCountry["name"]?["nativeName"]?[nativeNameAb]?["common"]?.ToString()
                };

                country.Region = jsonCountry["region"]?.ToString();
                country.Languages = new List<string>();
                var langKeys = jsonCountry["languages"]?
                    .ToObject<JObject>()?
                    .Properties()
                    .Select(p => p.Name)
                    .ToList() 
                    ?? new List<string>();
                
                foreach (var key in langKeys)
                {
                    country.Languages.Add(jsonCountry["languages"]?[key]?.ToString() ?? string.Empty);
                }

                country.Population = jsonCountry["population"].Value<long>();
                country.Flag = jsonCountry["flags"]?["svg"]?.ToString();

                res.Add(country);
            }

            return res;
        }
    }
}
