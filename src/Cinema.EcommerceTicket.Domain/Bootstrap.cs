using Cinema.EcommerceTicket.Domain.Services;
using Cinema.EcommerceTicket.Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.EcommerceTicket.Domain;

public static class Bootstrap
{
    public static void AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<ITicketService, TicketService>();
    }
}
