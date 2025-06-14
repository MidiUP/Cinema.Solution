using Cinema.APIGateway.Domain.Dtos.Requests.EcommerceTicket;
using Cinema.APIGateway.Domain.Dtos.Responses.EcommerceTicket;
using Cinema.APIGateway.Domain.Models.EcommerceTicket;
using Cinema.Events;

namespace Cinema.APIGateway.Domain.Mappers.EcommerceTicket;

public static class EcommerceTicketMappers
{
    public static EcommerceCreateTicketEvent MapToEcommerceCreateTicketEvent(this CheckInModel checkInModel)
    {
        return new EcommerceCreateTicketEvent
        {
            MovieId = checkInModel.MovieId,
            CustomerId = checkInModel.CustomerId
        };
    }

    public static CheckInModel MapToCheckInModel(this CreateCheckInRequestDto request)
    {
        return new CheckInModel
        {
            CustomerId = request.CustomerId,
            MovieId = request.MovieId
        };
    }

    public static GetTicketResponseDto MapToGetTicketResponseDto(this TicketModel ticketModel)
    {
        return new GetTicketResponseDto
        {
            Id = ticketModel.Id,
            CheckInId = ticketModel.CheckInId,
            CreatedAt = ticketModel.CreatedAt,
            CustomerId = ticketModel.CustomerId,
            MovieId = ticketModel.MovieId,
            Price = ticketModel.Price
        };
    }
}
