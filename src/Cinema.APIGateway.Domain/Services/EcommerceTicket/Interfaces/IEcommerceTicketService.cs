using Cinema.APIGateway.Domain.Models.EcommerceTicket;

namespace Cinema.APIGateway.Domain.Services.EcommerceTicket.Interfaces;

public interface IEcommerceTicketService
{
    public Task AddQueueCheckInMovieAsync(CheckInModel checkInModel);
}
