using Cinema.APIGateway.Domain.Models.EcommerceTicket;

namespace Cinema.APIGateway.Domain.Infrastructure.ApiFacades;

/// <summary>
/// Interface para o facade de integração com a API de tickets de e-commerce.
/// </summary>
/// <remarks>
/// Define operações para consulta de tickets de ingresso, encapsulando a comunicação com serviços externos de e-commerce de ingressos.
/// </remarks>
public interface IEcommerceTicketApiFacade
{
    /// <summary>
    /// Obtém todos os tickets de ingresso disponíveis.
    /// </summary>
    /// <param name="cancellationToken">Token para cancelamento da operação assíncrona.</param>
    /// <returns>Uma coleção de <see cref="TicketModel"/> representando os tickets encontrados.</returns>
    public Task<IEnumerable<TicketModel>> GetTicketsAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Obtém todos os tickets de ingresso associados a um cliente específico.
    /// </summary>
    /// <param name="customerId">Identificador do cliente.</param>
    /// <param name="cancellationToken">Token para cancelamento da operação assíncrona.</param>
    /// <returns>Uma coleção de <see cref="TicketModel"/> representando os tickets do cliente informado.</returns>
    public Task<IEnumerable<TicketModel>> GetTicketsByCustomerIdAsync(int customerId, CancellationToken cancellationToken);
}

