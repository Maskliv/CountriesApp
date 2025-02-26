using CountriesApp.Server.Middleware;

namespace CountriesApp.Server.AppStartup;

internal static class ExceptionMiddlewareConfig
{
    internal static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
    {
        if (app == null)
            throw new ArgumentNullException(nameof(app));

        return app.UseMiddleware<ExceptionMiddleware>();

    }
}