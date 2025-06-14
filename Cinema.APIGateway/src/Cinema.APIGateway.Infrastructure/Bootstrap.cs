using Cinema.APIGateway.Domain.Infrastructure.ApiAdapters;
using Cinema.APIGateway.Infrastructure.ApiFacades;
using Cinema.APIGateway.Infrastructure.HttpClients;
using Cinema.APIGateway.Infrastructure.RabbitMq;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.APIGateway.Infrastructure;

public static class Bootstrap
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddRabbitMq();
        services.AddHttpClients();
        services.AddApiFacades();
    }
    private static void AddApiFacades(this IServiceCollection services)
    {
        services.AddScoped<IEcommerceTicketApiFacade, EcommerceTicketApiFacade>();
        services.AddScoped<ICatalogApiFacade, CatalogApiFacade>();
    }
}
