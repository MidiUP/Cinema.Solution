using Cinema.APIGateway.Domain.Infrastructure.Repositories;
using Cinema.APIGateway.Infrastructure.Repositories.Catalog;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.APIGateway.Infrastructure;

public static class Bootstrap
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        AddRepositories(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<ICatalogRepository, CatalogRepository>();
    }
}
