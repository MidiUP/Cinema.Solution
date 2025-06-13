namespace Cinema.Catalog.Infrastructure.HttpClients.GatewayAdapters;

public abstract class GatewayAdapterBase
{
    protected abstract HttpClient? Client { get; set; }
    public abstract Task Authenticate(HttpRequestMessage requestMessage);
}
