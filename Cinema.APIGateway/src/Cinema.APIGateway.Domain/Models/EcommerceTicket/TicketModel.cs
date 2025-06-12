namespace Cinema.APIGateway.Domain.Models.EcommerceTicket;

public class TicketModel
{
    /// <summary>
    /// Identificador do ticket
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// Identificador do filme
    /// </summary>
    public int MovieId { get; set; }

    /// <summary>
    /// Identificador do cliente
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// Identificador do checkin
    /// </summary>
    public int CheckInId { get; set; }

    /// <summary>
    /// Preco do ticket
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// Data de criação do ticket
    /// </summary>
    public DateTime CreatedAt { get; set; }

}
