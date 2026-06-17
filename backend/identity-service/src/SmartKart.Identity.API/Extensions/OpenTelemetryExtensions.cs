namespace SmartKart.Identity.API.Extensions;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;


public static class OpenTelemetryExtensions
{
    public static IServiceCollection AddOpenTelemetryConfiguration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var serviceName =
            configuration["OpenTelemetry:ServiceName"]
            ?? "identity-service";

        services.AddOpenTelemetry()
            .ConfigureResource(resource =>
            {
                resource.AddService(
                    serviceName: serviceName,
                    serviceVersion: "1.0.0");
            })
            .WithTracing(tracing =>
            {
                tracing
                    .AddAspNetCoreInstrumentation(options =>
                    {
                        options.RecordException = true;

                        options.Filter = context =>
                        {
                            return !context.Request.Path.StartsWithSegments("/health");
                        };
                    })
                    .AddHttpClientInstrumentation(options =>
                    {
                        options.RecordException = true;
                    })
                    .AddSqlClientInstrumentation(options =>
                    {
                        options.RecordException = true;
                    });

                tracing.AddOtlpExporter();
            });

        return services;
    }
}
