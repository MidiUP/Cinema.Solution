using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Cinema.APIGateway.Domain.Dtos.Requests.EcommerceTicket;

/// <summary>
/// DTO para requisição de criação de check-in de ingresso de cinema.
/// </summary>
/// <remarks>
/// Utilizado para enviar os dados necessários para registrar o check-in de um cliente em um filme específico.
/// </remarks>
[ExcludeFromCodeCoverage]
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
