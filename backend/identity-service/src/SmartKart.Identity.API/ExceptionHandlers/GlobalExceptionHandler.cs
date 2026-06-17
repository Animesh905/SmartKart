using Microsoft.AspNetCore.Diagnostics;
using SmartKart.Identity.API.Contracts;
using System.Diagnostics;

namespace SmartKart.Identity.API.ExceptionHandlers;

public sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(
        ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken)
    {
        var traceId = 
            Activity.Current?.TraceId.ToString() 
            ?? httpContext.TraceIdentifier;

        _logger.LogError(exception, 
            "An unhandled exception occurred while processing the request. TraceId: {TraceId}"
            , traceId);

        var response = new ErrorResponse(
            false,
            "An unexpected error occurred.",
            traceId);

        httpContext.Response.StatusCode =
            StatusCodes.Status500InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(
            response,
            cancellationToken);

        return true;
    }
}
