using CountriesApp.Server.Domain.Exceptions;
using System.Net;
using CountriesApp.Server.Domain.Dto;

namespace CountriesApp.Server.Middleware;

public class ExceptionMiddleware(RequestDelegate next, IConfiguration configuration)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            if (httpContext.Response.HasStarted) return;
            
            await next(httpContext);
            

        }
        catch (Exception ex)
        {
            await HandleGlobalExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleGlobalExceptionAsync(HttpContext context, Exception ex)
    {

        context.Response.ContentType = "application/json";

        switch (ex)
        {
            case BadRequestException _:
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                break;
            case NotFoundException _:
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                break;
            default:
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }

        await context.Response.WriteAsync(new ErrorResponse(ex.Message).ToString());
    }
}