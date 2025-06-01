namespace Cinema.APIGateway.Domain.Services.EcommerceTicket.Interfaces;

public interface IEcommerceTicketService
{
    public Task AddQueueCheckInMovieAsync(int movieId);
}
