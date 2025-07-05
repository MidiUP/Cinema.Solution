namespace Cinema.APIGateway.Domain.Models.EcommerceTicket;

/// <summary>
/// Modelo de domínio que representa um ticket de ingresso de cinema.
/// </summary>
/// <remarks>
/// Contém as principais informações de um ticket, incluindo identificadores, preço e data de criação.
/// Utilizado em operações de consulta e manipulação de tickets no domínio de e-commerce de ingressos.
/// </remarks>
public class TicketModel
{
    /// <summary>
    /// Identificador do ticket.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// Identificador do filme associado ao ticket.
    /// </summary>
    public int MovieId { get; set; }

    /// <summary>
    /// Identificador do cliente associado ao ticket.
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// Identificador do check-in relacionado ao ticket.
    /// </summary>
    public int CheckInId { get; set; }

    /// <summary>
    /// Preço do ticket.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Data de criação do ticket.
    /// </summary>
    public DateTime CreatedAt { get; set; }
}

