namespace CountriesApp.Test;

using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.Metrics;
using CountriesApp.Server.Domain.Dto;

[TestFixture]
public class CountriesApiTests
{
    private HttpClient _httpClient;
    private CustomWebAppFactory<CountriesApp.Server.Program> _appFactory;
    private const string COUNTRIES_GETALL = "Countries/GetAll";
    private const string COUNTRIES_GETBYREGION = "Countries/GetByRegion";
    private const string COUNTRIES_GETBYNAME = "Countries/GetByName";

    [SetUp]
    public void Setup()
    {
        _appFactory = new CustomWebAppFactory<CountriesApp.Server.Program>();
        _httpClient = _appFactory.CreateClient();
    }

    [Test]
    public async Task GetCountries_ReturnsAllRequiredFields()
    {
        // Act
        var response = await _httpClient.GetAsync($"api/{COUNTRIES_GETALL}");

        // Assert
        Assert.That(response.IsSuccessStatusCode, Is.True, "Get all bad response. Status code: " + response.StatusCode);

        
        var content = await response.Content.ReadAsStringAsync();
        var countries = JsonConvert.DeserializeObject<List<Country>>(content);

        // Lista de paises no vacía
        Assert.That(countries, Is.Not.Empty, "Countries List empty");

        // Validar campos para cada país
        foreach (var country in countries)
        {
            
            Assert.That(country.Name, Is.Not.Null, "'name' null");
            Assert.That(country.Name.Common, Is.Not.Empty, "'name.common' empty");

            
            Assert.That(country.Region, Is.Not.Empty, "'region' empty");

            
            Assert.That(country.Population, Is.GreaterThan(-1), "pop must be positive number"); 

            
            //Assert.That(country.Languages, Is.Not.Empty, "languages empty"); // Hay paises que vienen sin esta lista
            //Assert.That(country.Languages.All(l => !string.IsNullOrEmpty(l)), "a language empty");

            // Flag (URL válida)
            Assert.That(country.Flag, Does.StartWith("http"), "url to flag not valid");
        }
    }

    [Test]
    public async Task GetCountriesByRegion_ReturnsAllRequiredFields()
    {
        // Act
        var response = await _httpClient.GetAsync($"api/{COUNTRIES_GETBYREGION}/America");

        // Assert
        Assert.That(response.IsSuccessStatusCode, Is.True, "Get by region bad response. Status code: " + response.StatusCode);


        var content = await response.Content.ReadAsStringAsync();
        var countries = JsonConvert.DeserializeObject<List<Country>>(content);

        // Lista de paises no vacía
        Assert.That(countries, Is.Not.Empty, "Countries List empty");

        // Validar campos para cada país
        foreach (var country in countries)
        {

            Assert.That(country.Name, Is.Not.Null, "'name' null");
            Assert.That(country.Name.Common, Is.Not.Empty, "'name.common' empty");


            Assert.That(country.Region, Is.Not.Empty, "'region' empty");


            Assert.That(country.Population, Is.GreaterThan(-1), "pop must be positive number");


            //Assert.That(country.Languages, Is.Not.Empty, "languages empty"); // Hay paises que vienen sin esta lista
            //Assert.That(country.Languages.All(l => !string.IsNullOrEmpty(l)), "a language empty");

            // Flag (URL válida)
            Assert.That(country.Flag, Does.StartWith("http"), "url to flag not valid");
        }
    }

    [Test]
    public async Task GetCountriesByName_ReturnsAllRequiredFields()
    {
        // Act
        var response = await _httpClient.GetAsync($"api/{COUNTRIES_GETBYNAME}/Colombia");

        // Assert
        Assert.That(response.IsSuccessStatusCode, Is.True, "Get by region bad response. Status code: " + response.StatusCode);


        var content = await response.Content.ReadAsStringAsync();
        var countries = JsonConvert.DeserializeObject<List<Country>>(content);

        // Lista de paises no vacía
        Assert.That(countries, Is.Not.Empty, "Countries List empty");

        // Validar campos para cada país
        foreach (var country in countries)
        {

            Assert.That(country.Name, Is.Not.Null, "'name' null");
            Assert.That(country.Name.Common, Is.Not.Empty, "'name.common' empty");


            Assert.That(country.Region, Is.Not.Empty, "'region' empty");


            Assert.That(country.Population, Is.GreaterThan(-1), "pop must be positive number");


            //Assert.That(country.Languages, Is.Not.Empty, "languages empty"); // Hay paises que vienen sin esta lista
            //Assert.That(country.Languages.All(l => !string.IsNullOrEmpty(l)), "a language empty");

            // Flag (URL válida)
            Assert.That(country.Flag, Does.StartWith("http"), "url to flag not valid");
        }
    }

    [TearDown]
    public void TearDown()
    {
        _httpClient.Dispose();
        _appFactory.Dispose();
    }
}