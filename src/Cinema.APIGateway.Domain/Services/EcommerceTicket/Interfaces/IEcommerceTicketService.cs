using Cinema.APIGateway.Domain.Models.EcommerceTicket;

namespace Cinema.APIGateway.Domain.Services.EcommerceTicket.Interfaces;

/// <summary>
/// Interface para o serviço de e-commerce de tickets de cinema.
/// </summary>
/// <remarks>
/// Define operações de negócio para registrar check-in de ingressos e consultar tickets, incluindo busca geral e por cliente.
/// </remarks>
public interface IEcommerceTicketService
{
    /// <summary>
    /// Adiciona um novo check-in de ingresso na fila para processamento.
    /// </summary>
    /// <param name="checkInModel">Modelo contendo os dados do check-in a ser registrado.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task AddQueueCheckInMovieAsync(CheckInModel checkInModel);

    /// <summary>
    /// Obtém todos os tickets de ingresso disponíveis.
    /// </summary>
    /// <returns>Uma coleção de <see cref="TicketModel"/> representando os tickets encontrados.</returns>
    Task<IEnumerable<TicketModel>> GetTicketsAsync();

    /// <summary>
    /// Obtém todos os tickets de ingresso associados a um cliente específico.
    /// </summary>
    /// <param name="customerId">Identificador do cliente.</param>
    /// <returns>Uma coleção de <see cref="TicketModel"/> representando os tickets do cliente informado.</returns>
    Task<IEnumerable<TicketModel>> GetTicketsByCustomerIdAsync(int customerId);
}

