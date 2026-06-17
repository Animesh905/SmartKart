using System.Diagnostics;

namespace SmartKart.Identity.API.Middleware;

public sealed class ResponseHeaderMiddleware
{
    private readonly RequestDelegate _next;

    public ResponseHeaderMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.OnStarting(() =>
        {
            var traceId = Activity.Current?.TraceId.ToString();

            if (!string.IsNullOrWhiteSpace(traceId))
            {
                context.Response.Headers["X-Trace-Id"] = traceId;
            }

            return Task.CompletedTask;
        });

        await _next(context);
    }
}