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
        //services
        //    .Scan(scan => scan
        //    .FromAssemblyOf<ICategoryService>() // ICategoryService'in bulunduğu assembly'i al
        //    .AddClasses(classes => classes
        //    .AssignableTo(typeof(IGenericRepository<>))) // Bu assembly'deki ICategoryService türüne atanabilir olan tüm sınıfları ekle
        //    .AsImplementedInterfaces()  // Sınıfları, implement ettikleri tüm interface'ler ile DI'ye kaydet
        //    .WithScopedLifetime()); // Bu sınıfları Scoped yaşam süresiyle kaydet

        services
            .AddScoped<IAuthService, AuthService>()
            .AddScoped<ICategoryService, CategoryService>()
            .AddScoped<IMenuItemService, MenuItemService>()
            .AddScoped<IOrderService, OrderService>()
            .AddScoped<IOrderItemService, OrderItemService>()
            .AddScoped<ITableService, TableService>();

        services
            .Scan(scan => scan
            .FromAssemblyOf<CategoryBusinessRules>() // BusinessRules sınıflarının bulunduğu assembly'yi seç
            .AddClasses(classes => classes.AssignableTo<BusinessRules>()) // BusinessRules sınıfına atanabilir olan tüm sınıfları seç
            .AsSelf() // Kendisiyle (sınıf ismiyle) DI'ye kaydet
            .WithScopedLifetime()); // Scoped olarak kaydet

        services
            .AddScoped<CreateService>()
            .AddScoped<UpdateService>()
            .AddScoped<TokenHelper>();

        services
            .AddScoped<IValidationHelper, ValidationHelper>()
            .AddValidatorsFromAssembly(typeof(ApplicationServiceRegistration).Assembly);

        services
            .AddAutoMapper(typeof(GeneralMapping));

        return services;
    }
}