using Cinema.APIGateway.Domain.Infrastructure.ApiFacades;
using Cinema.APIGateway.Domain.Models.EcommerceTicket;
using Cinema.APIGateway.Domain.Shared;
using Cinema.APIGateway.Infrastructure.HttpClients;
using Microsoft.Extensions.Options;

namespace Cinema.APIGateway.Infrastructure.ApiFacades;

class EcommerceTicketApiFacade : IEcommerceTicketApiFacade
{
    private readonly EcommerceTicketApiOptions _ecommerceTicketApiOptions;
    private readonly HttpClient _httpClient;

    public EcommerceTicketApiFacade(IHttpClientFactory httpClientFactory, IOptions<EcommerceTicketApiOptions> ecommerceTicketApiOptions)
    {
        _ecommerceTicketApiOptions = ecommerceTicketApiOptions.Value;
        _httpClient = httpClientFactory.CreateClient(_ecommerceTicketApiOptions.Name);
    }

    public async Task<IEnumerable<TicketModel>> GetTicketsAsync(CancellationToken cancellationToken)
    {
        var path = "v1/tickets";
        return await _httpClient.GetAsync<IEnumerable<TicketModel>>(path, null, cancellationToken);
    }

    public async Task<IEnumerable<TicketModel>> GetTicketsByCustomerIdAsync(int customerId, CancellationToken cancellationToken)
    {
        var path = $"v1/tickets/{customerId}";
        return await _httpClient.GetAsync<IEnumerable<TicketModel>>(path, null, cancellationToken);
    }
}
