using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xurmo.Common.Presentation.Endpoints;
using Xurmo.Modules.Catalogs.Application.Abstractions.Data;
using Xurmo.Modules.Catalogs.Domain.Products;
using Xurmo.Modules.Catalogs.Infrastructure.Database;
using Xurmo.Modules.Catalogs.Infrastructure.Products;

namespace Xurmo.Modules.Catalogs.Infrastructure;
public static class CatalogsModule
{
    public static IServiceCollection AddCatalogsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);

        services.AddEndpoints(Presentation.AssemblyReference.Assembly);

        return services;
    }

    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CatalogsDbContext>((sp, options) =>
            options
                .UseNpgsql(
                    configuration.GetConnectionString("Database"),
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Catalogs))
                .UseSnakeCaseNamingConvention()
                );

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<CatalogsDbContext>());

        services.AddScoped<IProductRepository, ProductRepository>();
    }
}
