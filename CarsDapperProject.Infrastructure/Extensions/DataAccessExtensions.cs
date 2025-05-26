using CarsDapperProject.Contracts.Settings;
using CarsDapperProject.DataAccess.Dapper;
using CarsDapperProject.DataAccess.Repositories;
using CarsDapperProject.Domain.Migrations;
using CarsDapperProject.Domain.Repositories;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarsDapperProject.DataAccess.Extensions;

public static class DataAccessExtensions
{
    public static IServiceCollection AddDapper(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDapperContext, DapperContext>();

        services.Configure<DapperSettings>(o =>
        {
            o.ConnectionString = configuration.GetConnectionString("DefaultConnection")!;
        });

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<IOwnerRepository, OwnerRepository>();

        return services;
    }

    public static IServiceCollection AddFluentMigrator(this IServiceCollection services, IConfiguration configuration)
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

        return services;
    }

    public static IServiceCollection MigrateUp(this IServiceCollection services)
    {
        using (var scope = services.BuildServiceProvider().CreateScope())
        {
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            runner.ListMigrations();
            runner.MigrateUp();
        }

        return services;
    }
}
