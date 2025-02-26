using Newtonsoft.Json;

namespace CountriesApp.Server.Domain.Dto;

public class ErrorResponse(string description)
{
    public string Error { get; set; } = description;

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}