namespace Cinema.APIGateway.Domain.Dtos.Requests.EcommerceTicket;

public record CreateCheckInRequestDto
{
    /// <summary>
    /// Identificador do filme.
    /// </summary>
    public int MovieId { get; set; }
    
    /// <summary>
    /// Identificador do cliente.
    /// </summary>
    public int CustomerId { get; set; }
}
