using SmartKart.Identity.API.Middleware;

namespace SmartKart.Identity.API.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseApplicationMiddleware(
        this IApplicationBuilder app)
    {
        app.UseExceptionHandler();

        app.UseMiddleware<CorrelationIdMiddleware>();

        app.UseMiddleware<ResponseHeaderMiddleware>();

        app.UseMiddleware<RequestLoggingMiddleware>();

        return app;
    }
}
