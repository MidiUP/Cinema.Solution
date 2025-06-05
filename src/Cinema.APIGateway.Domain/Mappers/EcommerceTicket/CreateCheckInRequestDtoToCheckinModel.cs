using Cinema.APIGateway.Domain.Dtos.Requests.EcommerceTicket;
using Cinema.APIGateway.Domain.Models.EcommerceTicket;

namespace Cinema.APIGateway.Domain.Mappers.EcommerceTicket;

public static class CreateCheckInRequestDtoToCheckinModel
{
    public static CheckInModel MapToCheckInModel(this CreateCheckInRequestDto request)
    {
        return new CheckInModel
        {
            CustomerId = request.CustomerId,
            MovieId = request.MovieId
        };
    }
}
