using CarsDapperProject.Application.Services;
using CarsDapperProject.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CarsDapperProject.Application.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<ICarService, CarService>();

        return services;
    }
}
