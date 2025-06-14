using Cinema.APIGateway.Domain.Infrastructure.ApiAdapters;
using Cinema.APIGateway.Domain.Models.EcommerceTicket;
using Cinema.APIGateway.Domain.Shared;
using Cinema.APIGateway.Infrastructure.HttpClients;

namespace Cinema.APIGateway.Infrastructure.ApiFacades;

class EcommerceTicketApiFacade(IHttpClientFactory httpClientFactory) : IEcommerceTicketApiFacade
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient(Constants.EcommerceTicketApi.NAME);

    public async Task<IEnumerable<TicketModel>> GetTicketsAsync(CancellationToken cancellationToken)
    {
        var path = "v1/ticket";
        return await _httpClient.GetAsync<IEnumerable<TicketModel>>(path, null, cancellationToken);
    }

    public async Task<IEnumerable<TicketModel>> GetTicketsByCustomerIdAsync(int customerId, CancellationToken cancellationToken)
    {
        var path = $"v1/ticket/{customerId}";
        return await _httpClient.GetAsync<IEnumerable<TicketModel>>(path, null, cancellationToken);
    }
}
