using CarsDapperProject.Application.Services;
using CarsDapperProject.Contracts.Services;
using CarsDapperProject.Contracts.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarsDapperProject.Application.Extensions;

public static class ApplicationExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<CarService>();

        return services;
    }

    public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DapperSettings>(o =>
        {
            o.ConnectionString = configuration.GetConnectionString("DefaultConnection")!;
        });

        return services;
    }
}
