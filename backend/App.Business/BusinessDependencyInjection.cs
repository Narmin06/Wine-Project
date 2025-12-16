using App.Core.DTOs.Commons;
using App.Business.Helpers;
using App.Business.Services.ExternalServices.Abstractions;
using App.Business.Services.ExternalServices.Interfaces;
using App.Business.Services.InternalServices.Abstractions;
using App.Business.Services.InternalServices.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using FluentValidation;

namespace App.Business;

public static class BusinessDependencyInjection
{
    public static IServiceCollection AddBusiness(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddServices();
        services.RegisterAutoMapper();
        services.AddControllers(options =>
        {
            options.Conventions.Add(new PluralizedRouteConvention());
            options.ModelValidatorProviders.Clear();
        })
       .AddFluentValidation(fv => fv
       .RegisterValidatorsFromAssemblyContaining<AbstractValidator<BaseEntityDTO>>())
       .AddJsonOptions(options =>
       {
           options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
       });

        return services;
    }

    private static void AddServices(this IServiceCollection services)
    {
        // External Services 
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IFileManagerService, FileManagerService>();

        // Internal Services
        services.AddScoped<IUserService, UserService>();
        
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ISubCategoryService, SubCategoryService>();
        
        services.AddScoped<ISlideService, SlideService>();
        services.AddScoped<ISettingService, SettingService>();

        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductFieldService, ProductFieldService>();
        services.AddScoped<IProductDetailService, ProductDetailService>();

    }

    private static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(BusinessDependencyInjection));
    }
}
