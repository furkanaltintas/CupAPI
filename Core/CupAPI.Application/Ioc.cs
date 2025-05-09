using CupAPI.Application.Common.Helpers;
using CupAPI.Application.Common.Rules.CategoryRules;
using CupAPI.Application.Common.Rules.MenuItemRules;
using CupAPI.Application.Common.Rules.TableRules;
using CupAPI.Application.Common.Services;
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
        services.AddScoped<ITableService, TableService>();
        services.AddScoped<IValidationHelper, ValidationHelper>();

        services.AddScoped<CreateService>();
        services.AddScoped<UpdateService>();
        services.AddScoped<CategoryBusinessRules>();
        services.AddScoped<MenuItemBusinessRules>();
        services.AddScoped<TableBusinessRules>();

        services.AddValidatorsFromAssembly(typeof(Ioc).Assembly);
        services.AddAutoMapper(typeof(GeneralMapping));


        return services;
    }
}