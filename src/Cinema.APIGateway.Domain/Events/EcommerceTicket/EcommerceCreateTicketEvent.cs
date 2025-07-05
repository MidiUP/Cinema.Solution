using System.Diagnostics.CodeAnalysis;

namespace Cinema.Events;

/// <summary>
/// Evento de criação de ticket de ingresso de cinema no e-commerce.
/// </summary>
/// <remarks>
/// Representa os dados necessários para notificar a criação de um novo ticket, incluindo o identificador do filme e do cliente.
/// </remarks>
[ExcludeFromCodeCoverage]
public class EcommerceCreateTicketEvent : Event
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
