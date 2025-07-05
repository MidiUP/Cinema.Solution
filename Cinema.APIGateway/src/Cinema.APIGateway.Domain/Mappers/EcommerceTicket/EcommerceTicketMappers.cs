using Cinema.APIGateway.Domain.Dtos.Requests.EcommerceTicket;
using Cinema.APIGateway.Domain.Dtos.Responses.EcommerceTicket;
using Cinema.APIGateway.Domain.Models.EcommerceTicket;
using Cinema.Events;

namespace Cinema.APIGateway.Domain.Mappers.EcommerceTicket;

/// <summary>
/// Métodos de extensão para mapear objetos relacionados a tickets de e-commerce.
/// </summary>
/// <remarks>
/// Fornece conversões entre modelos de domínio, DTOs de requisição/resposta e eventos para operações de tickets de cinema.
/// </remarks>
public static class EcommerceTicketMappers
{
    private static readonly TimeZoneInfo _brasiliaTimeZone = TimeZoneInfo.FindSystemTimeZoneById(
        OperatingSystem.IsWindows() ? "E. South America Standard Time" : "America/Sao_Paulo"
    );

    /// <summary>
    /// Converte um <see cref="CheckInModel"/> em um <see cref="EcommerceCreateTicketEvent"/>.
    /// </summary>
    /// <param name="checkInModel">Modelo de domínio do check-in.</param>
    /// <returns>Instância de <see cref="EcommerceCreateTicketEvent"/> preenchida com os dados do check-in.</returns>
    public static EcommerceCreateTicketEvent MapToEcommerceCreateTicketEvent(this CheckInModel checkInModel)
    {
        return new EcommerceCreateTicketEvent
        {
            MovieId = checkInModel.MovieId,
            CustomerId = checkInModel.CustomerId
        };
    }

    /// <summary>
    /// Converte um <see cref="CreateCheckInRequestDto"/> em um <see cref="CheckInModel"/>.
    /// </summary>
    /// <param name="request">DTO de requisição de criação de check-in.</param>
    /// <returns>Instância de <see cref="CheckInModel"/> preenchida com os dados do DTO.</returns>
    public static CheckInModel MapToCheckInModel(this CreateCheckInRequestDto request)
    {
        return new CheckInModel
        {
            CustomerId = request.CustomerId,
            MovieId = request.MovieId
        };
    }

    /// <summary>
    /// Converte um <see cref="TicketModel"/> em um <see cref="GetTicketResponseDto"/>,
    /// ajustando a data de criação para o fuso horário de Brasília.
    /// </summary>
    /// <param name="ticketModel">Modelo de domínio do ticket.</param>
    /// <returns>Instância de <see cref="GetTicketResponseDto"/> preenchida com os dados do modelo.</returns>
    public static GetTicketResponseDto MapToGetTicketResponseDto(this TicketModel ticketModel)
    {
        return new GetTicketResponseDto
        {
            Id = ticketModel.Id,
            CheckInId = ticketModel.CheckInId,
            CreatedAt = TimeZoneInfo.ConvertTimeFromUtc(ticketModel.CreatedAt, _brasiliaTimeZone),
            CustomerId = ticketModel.CustomerId,
            MovieId = ticketModel.MovieId,
            Price = ticketModel.Price
        };
    }
}

