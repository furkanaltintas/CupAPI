using CupAPI.Application.Mappings;
using CupAPI.Application.Services.Abstract;
using CupAPI.Application.Services.Concrete;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CupAPI.Application;

public static class Ioc
{
    public static IServiceCollection ApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IMenuItemService, MenuItemService>();

        services.AddAutoMapper(typeof(GeneralMapping));

        //services.AddValidatorsFromAssemblyContaining<CreateCategoryDto>();
        //services.AddValidatorsFromAssemblyContaining<UpdateCategoryDto>();
        services.AddValidatorsFromAssembly(typeof(Ioc).Assembly);

        return services;
    }
}