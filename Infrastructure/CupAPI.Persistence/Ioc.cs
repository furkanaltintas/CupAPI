using CupAPI.Application.Interfaces;
using CupAPI.Persistence.Context;
using CupAPI.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CupAPI.Persistence;

public static class Ioc
{
    public static IServiceCollection PersistenceService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ITableRepository, TableRepository>();

        return services;
    }
}