using Cinema.APIGateway.Domain.Infrastructure.ApiFacades;
using Cinema.APIGateway.Infrastructure.ApiFacades;
using Cinema.APIGateway.Infrastructure.HttpClients;
using Cinema.APIGateway.Infrastructure.RabbitMq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.APIGateway.Infrastructure;

public static class Bootstrap
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRabbitMq(configuration);
        services.AddHttpClients(configuration);
        services.AddApiFacades();
    }
    private static void AddApiFacades(this IServiceCollection services)
    {
        services.AddScoped<IEcommerceTicketApiFacade, EcommerceTicketApiFacade>();
        services.AddScoped<ICatalogApiFacade, CatalogApiFacade>();
    }
}
