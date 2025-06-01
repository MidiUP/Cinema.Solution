using Cinema.APIGateway.Domain.Services.Catalog;
using Cinema.APIGateway.Domain.Services.Catalog.Interfaces;
using Cinema.APIGateway.Domain.Services.EcommerceTicket;
using Cinema.APIGateway.Domain.Services.EcommerceTicket.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.APIGateway.Domain;

public static class Bootstrap
{
    public static void AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<ICatalogService, CatalogService>();
        services.AddScoped<IEcommerceTicketService, EcommerceTicketService>();
    }
}
