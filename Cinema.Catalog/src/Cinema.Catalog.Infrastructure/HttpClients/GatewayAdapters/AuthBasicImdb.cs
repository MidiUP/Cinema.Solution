
using Cinema.Catalog.Domain.Shared;

namespace Cinema.Catalog.Infrastructure.HttpClients.GatewayAdapters;

class AuthBasicImdb : GatewayAdapterBase
{
    protected override HttpClient? Client { get; set; } = null;

    private readonly string AUTH_TOKEN = Constants.TmdbApi.AUTH_TOKEN;

    public override Task Authenticate(HttpRequestMessage requestMessage)
    {
        requestMessage.Headers.TryAddWithoutValidation("Accept", "application/json");
        requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AUTH_TOKEN);
        return Task.CompletedTask;
    }
}
