using Cinema.APIGateway.Domain.Services.Catalog;
using Cinema.APIGateway.Domain.Services.Catalog.Interfaces;
using Cinema.APIGateway.Domain.Services.EcommerceTicket;
using Cinema.APIGateway.Domain.Services.EcommerceTicket.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.APIGateway.Domain;

/// <summary>
/// Classe utilitária responsável pelo registro dos serviços de domínio no container de injeção de dependência.
/// </summary>
/// <remarks>
/// Centraliza a configuração dos serviços de domínio, facilitando a manutenção e a organização das dependências da aplicação.
/// </remarks>
public static class Bootstrap
{
    /// <summary>
    /// Adiciona os serviços de domínio ao container de injeção de dependência.
    /// </summary>
    /// <param name="services">Coleção de serviços da aplicação.</param>
    /// <remarks>
    /// Registra as implementações de <see cref="ICatalogService"/> e <see cref="IEcommerceTicketService"/> como serviços com ciclo de vida Scoped.
    /// </remarks>
    public static void AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<ICatalogService, CatalogService>();
        services.AddScoped<IEcommerceTicketService, EcommerceTicketService>();
    }
}

