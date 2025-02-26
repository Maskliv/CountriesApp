using CountriesApp.Server.Domain.Variables;

namespace CountriesApp.Server.AppStartup;

internal static class CorsConfig
{
    internal static IServiceCollection AddCorsDocumentation(this IServiceCollection services, IConfiguration config)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(config[AppSettingsKeys.CORS_NAME], builder => {
                builder.WithOrigins(config[AppSettingsKeys.CORS_CLIENT])
                        .AllowAnyHeader()
                        .AllowAnyMethod();

            });
        });
        return services;
    }

    internal static IApplicationBuilder UseCorsDocumentation(this IApplicationBuilder app)
    {
        app.UseCors(AppSettingsKeys.CORS_NAME);
        return app;
    }
}