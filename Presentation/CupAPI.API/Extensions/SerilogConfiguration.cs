using Serilog;

namespace CupAPI.API.Extensions;

public static class SerilogConfiguration
{
    public static IServiceCollection AddSerilogService(this IServiceCollection services, IConfiguration configuration, ConfigureHostBuilder host)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .CreateLogger();

        services.AddSingleton<Serilog.ILogger>(Log.Logger);
        host.UseSerilog();

        return services;
    }
}