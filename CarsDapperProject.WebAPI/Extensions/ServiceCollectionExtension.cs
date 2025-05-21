using CarsDapperProject.Application.Services;
using CarsDapperProject.Contracts.Services;
using CarsDapperProject.Domain.Migrations;
using CarsDapperProject.Domain.Repositories;
using CarsDapperProject.Infrastructure.DataAccess;
using CarsDapperProject.Infrastructure.DataAccess.Repositories;
using FluentMigrator.Runner;

namespace CarsDapperProject.WebAPI.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBrandService, BrandService>();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(new DapperContext(configuration.GetConnectionString("DefaultConnection")!));

        services.AddScoped<IBrandRepository, BrandRepository>();

        return services;
    }

    public static IServiceCollection MigrateUp(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddLogging(x => x.AddFluentMigratorConsole())
            .AddFluentMigratorCore()
            .ConfigureRunner(builder => builder
                .AddPostgres()
                .WithGlobalConnectionString(configuration.GetConnectionString("DefaultConnection")!)
                .ScanIn(typeof(M000_Initial).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);

        using (var scope = services.BuildServiceProvider().CreateScope())
        {
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            runner.ListMigrations();
            runner.MigrateUp();
        }

        return services;
    }
}
