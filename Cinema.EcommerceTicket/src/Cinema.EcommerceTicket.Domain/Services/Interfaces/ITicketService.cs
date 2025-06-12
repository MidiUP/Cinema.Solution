using Cinema.EcommerceTicket.Domain.Models;

namespace Cinema.EcommerceTicket.Domain.Services.Interfaces;

public interface ITicketService
{
    Task CreateTicketAsync(TicketModel ticketModel);
    Task<IEnumerable<TicketModel>> GetTicketsByCostumerAsync(int customerId);
}
