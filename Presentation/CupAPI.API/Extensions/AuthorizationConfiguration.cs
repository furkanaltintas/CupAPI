using CupAPI.Domain.Enums;

namespace CupAPI.API.Extensions;

public static class AuthorizationConfiguration
{
    public static IServiceCollection AddAuthorizationService(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy(AuthorizationPolicy.AdminOnly, policy => policy.RequireRole(UserRole.Admin));
            options.AddPolicy(AuthorizationPolicy.AdminAndEmployeeOnly, policy => policy.RequireRole(UserRole.Admin, UserRole.Employee));
        });

        return services;
    }
}
