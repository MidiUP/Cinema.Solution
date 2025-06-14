using Newtonsoft.Json;

namespace Cinema.APIGateway.Domain.Dtos.Responses.EcommerceTicket;

public class GetTicketResponseDto
{
    /// <summary>
    /// Identificador do ticket
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// Identificador do filme
    /// </summary>
    [JsonProperty("idFilme")]
    public int MovieId { get; set; }

    /// <summary>
    /// Identificador do cliente
    /// </summary>
    [JsonProperty("idCliente")]
    public int CustomerId { get; set; }

    /// <summary>
    /// Identificador do checkin
    /// </summary>
    [JsonProperty("checkInId")]
    public int CheckInId { get; set; }

    /// <summary>
    /// Preco do ticket
    /// </summary>
    [JsonProperty("preco")]
    public decimal Price { get; set; }

    /// <summary>
    /// Data de criação do ticket
    /// </summary>
    [JsonProperty("criadoEm")]
    public DateTime CreatedAt { get; set; }
}
