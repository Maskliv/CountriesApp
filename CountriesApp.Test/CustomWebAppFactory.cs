using Microsoft.AspNetCore.Mvc.Testing;


namespace CountriesApp.Test
{
    class CustomWebAppFactory<TProgram>: WebApplicationFactory<TProgram> where TProgram: class
    {
        
    }
}
