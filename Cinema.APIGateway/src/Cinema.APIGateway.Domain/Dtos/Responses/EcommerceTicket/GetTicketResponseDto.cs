using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Cinema.APIGateway.Domain.Dtos.Responses.EcommerceTicket;

/// <summary>
/// DTO de resposta para consulta de ticket de ingresso de cinema.
/// </summary>
/// <remarks>
/// Contém as informações detalhadas de um ticket retornado pela API de e-commerce de ingressos.
/// </remarks>
[ExcludeFromCodeCoverage]
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
