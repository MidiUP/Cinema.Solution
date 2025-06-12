using Cinema.APIGateway.Domain.Dtos.Requests.EcommerceTicket;
using Cinema.Domain.Events;
using Cinema.APIGateway.Domain.Models.EcommerceTicket;

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
}
