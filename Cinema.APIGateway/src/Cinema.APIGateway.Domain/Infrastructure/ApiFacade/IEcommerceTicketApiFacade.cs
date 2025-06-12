using Cinema.APIGateway.Domain.Models.EcommerceTicket;

namespace Cinema.APIGateway.Domain.Infrastructure.ApiAdapters;

public interface IEcommerceTicketApiFacade 
{
    public Task<IEnumerable<TicketModel>> GetTicketsAsync(CancellationToken cancellationToken);
    public Task<IEnumerable<TicketModel>> GetTicketsByCustomerIdAsync(int customerId, CancellationToken cancellationToken);
}
