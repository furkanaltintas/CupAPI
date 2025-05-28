using CupAPI.Application.Common.Helpers.Jwt.Abstract;
using CupAPI.Application.Common.Helpers.Jwt.Concrete;
using CupAPI.Application.Common.Helpers.PasswordHasher.Abstract;
using CupAPI.Application.Common.Helpers.PasswordHasher.Concrete;
using CupAPI.Application.Common.Helpers.Validation.Abstract;
using CupAPI.Application.Common.Helpers.Validation.Concrete;
using CupAPI.Application.Common.Rules;
using CupAPI.Application.Common.Rules.CategoryRules;
using CupAPI.Application.Common.Services;
using CupAPI.Application.Interfaces;
using CupAPI.Application.Mappings;
using CupAPI.Application.Services.Abstract;
using CupAPI.Application.Services.Concrete;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CupAPI.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection ApplicationServices(this IServiceCollection services)
    {
        services
            .AddScoped<IAuthService, AuthService>()
            .AddScoped<ICategoryService, CategoryService>()
            .AddScoped<IMenuItemService, MenuItemService>()
            .AddScoped<IOrderService, OrderService>()
            .AddScoped<IOrderItemService, OrderItemService>()
            .AddScoped<ITableService, TableService>()
            .AddScoped<IUserService, UserService>();

        services
            .AddScoped<CreateService>()
            .AddScoped<UpdateService>();

        services
            .Scan(scan => scan
            .FromAssemblyOf<CategoryBusinessRules>() // BusinessRules sınıflarının bulunduğu assembly'yi seç
            .AddClasses(classes => classes.AssignableTo<BusinessRules>()) // BusinessRules sınıfına atanabilir olan tüm sınıfları seç
            .AsSelf() // Kendisiyle (sınıf ismiyle) DI'ye kaydet
            .WithScopedLifetime()); // Scoped olarak kaydet

        services
            .AddScoped<IJwtService, JwtService>()
            .AddScoped<IPasswordHasher, PasswordHasher>()
            .AddScoped<IValidationHelper, ValidationHelper>();

        services
            .AddScoped<IValidationHelper, ValidationHelper>()
            .AddValidatorsFromAssembly(typeof(ApplicationServiceRegistration).Assembly);

        services
            .AddAutoMapper(typeof(GeneralMapping));

        return services;
    }
}