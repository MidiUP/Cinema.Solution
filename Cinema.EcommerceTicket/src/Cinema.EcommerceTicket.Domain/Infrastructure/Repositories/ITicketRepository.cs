using Cinema.EcommerceTicket.Domain.Models;

namespace Cinema.EcommerceTicket.Domain.Infrastructure.Repositories;

public interface ITicketRepository
{
    Task CreateTicketAsync(TicketModel ticketModel);
    Task<IEnumerable<TicketModel>> GetTicketsByCustomerAsync(int customerId);
}
