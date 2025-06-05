using CupAPI.API.Extensions;
using CupAPI.API.Routing;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace CupAPI.API;

public static class PresentationServiceRegistration
{
    public static IServiceCollection PresentationService(this IServiceCollection services, IConfiguration configuration, ConfigureHostBuilder host)
    {
        services.AddControllers(options =>
        {
            options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
        });

        services.AddJwtAuthenticationService(configuration); // JWT Authentication
        services.AddAuthorizationService(); // Policy
        services.AddSerilogService(configuration, host); // Serilog

        return services;
    }
}