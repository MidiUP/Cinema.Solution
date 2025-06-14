using Newtonsoft.Json;

namespace Cinema.APIGateway.Domain.Dtos.Requests.EcommerceTicket;

public record CreateCheckInRequestDto
{
    /// <summary>
    /// Identificador do filme.
    /// </summary>
    [JsonProperty("idFilme")] 
    public int MovieId { get; set; }

    /// <summary>
    /// Identificador do cliente.
    /// </summary>
    [JsonProperty("idCliente")]
    public int CustomerId { get; set; }
}
