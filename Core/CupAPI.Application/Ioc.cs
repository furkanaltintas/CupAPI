using Microsoft.Extensions.DependencyInjection;
using CupAPI.Application.Services.Abstract;
using CupAPI.Application.Services.Concrete;
using CupAPI.Application.Mappings;
using FluentValidation;

namespace CupAPI.Application;

public static class Ioc
{
    public static IServiceCollection ApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IMenuItemService, MenuItemService>();

        services.AddAutoMapper(typeof(GeneralMapping));

        services.AddValidatorsFromAssembly(typeof(Ioc).Assembly);

        return services;
    }
}