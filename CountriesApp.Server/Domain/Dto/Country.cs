namespace CountriesApp.Server.Domain.Dto;

public class Country
{
    public NameInfo? Name { get; set; }
    public string? Region { get; set; }
    public long Population { get; set; }
    public List<string>? Languages { get; set; }
    public string? Flag { get; set;}
}
