using Serilog;
using SmartKart.Identity.API.ExceptionHandlers;
using SmartKart.Identity.API.Extensions;
using SmartKart.Identity.Application;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("logs/log-.txt",
        rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();

    builder.Services.AddControllers();

    builder.Services.AddOpenApi();

    builder.Services.AddProblemDetails();

    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

    builder.Services.AddOpenTelemetryConfiguration(
        builder.Configuration);

    builder.Services.AddApplication();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    app.UseHttpsRedirection();

    app.UseApplicationMiddleware();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    Log.Information("Identity Service Started Successfully");

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application startup failed");
}
finally
{
    Log.CloseAndFlush();
}