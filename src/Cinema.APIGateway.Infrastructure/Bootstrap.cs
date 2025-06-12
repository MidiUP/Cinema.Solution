using Cinema.APIGateway.Domain.Infrastructure.ApiAdapters;
using Cinema.APIGateway.Domain.Infrastructure.Repositories;
using Cinema.APIGateway.Infrastructure.ApiAdapters;
using Cinema.APIGateway.Infrastructure.HttpClients;
using Cinema.APIGateway.Infrastructure.RabbitMq;
using Cinema.APIGateway.Infrastructure.Repositories.Catalog;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.APIGateway.Infrastructure;

public static class Bootstrap
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddRabbitMq();
        services.AddRepositories();
        services.AddHttpClients();
        services.AddHttpClientsAdapter();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICatalogRepository, CatalogRepository>();
    }
    private static void AddHttpClientsAdapter(this IServiceCollection services)
    {
        services.AddScoped<IEcommerceTicketApiAdapter, EcommerceTicketApiAdapter>();
    }
}
