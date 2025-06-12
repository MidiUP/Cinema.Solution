using Cinema.APIGateway.Domain.Infrastructure.ApiAdapters;
using Cinema.APIGateway.Domain.Models.EcommerceTicket;
using Cinema.APIGateway.Domain.Shared;
using Cinema.APIGateway.Infrastructure.HttpClients;

namespace Cinema.APIGateway.Infrastructure.ApiAdapters;

class EcommerceTicketApiAdapter(IHttpClientFactory httpClientFactory) : IEcommerceTicketApiAdapter
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient(Constants.EcommerceTicketApi.NAME);
    private readonly HttpAdapter _httpAdapter = new();

    public async Task<IEnumerable<TicketModel>> GetTicketsAsync(CancellationToken cancellationToken)
    {
        var path = "v1/Ticket";
        return await _httpAdapter.GetAsync<IEnumerable<TicketModel>>(_httpClient, path, cancellationToken);
    }

    public async Task<IEnumerable<TicketModel>> GetTicketsByCustomerIdAsync(int customerId, CancellationToken cancellationToken)
    {
        var path = $"v1/Ticket/{customerId}";
        return await _httpAdapter.GetAsync<IEnumerable<TicketModel>>(_httpClient, path, cancellationToken);
    }
}
