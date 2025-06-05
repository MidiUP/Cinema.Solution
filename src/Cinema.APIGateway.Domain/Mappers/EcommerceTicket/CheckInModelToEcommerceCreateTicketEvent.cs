using Cinema.APIGateway.Domain.Events.EcommerceTicket;
using Cinema.APIGateway.Domain.Models.EcommerceTicket;

namespace Cinema.APIGateway.Domain.Mappers.EcommerceTicket;

public static class CheckInModelToEcommerceCreateTicketEvent
{
    public static EcommerceCreateTicketEvent MapToEcommerceCreateTicketEvent(this CheckInModel checkInModel)
    {
        return new EcommerceCreateTicketEvent
        {
            MovieId = checkInModel.MovieId,
            CustomerId = checkInModel.CustomerId
        };
    }
}
