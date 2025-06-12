namespace Cinema.APIGateway.Domain.Infrastructure;

public abstract class GatewayAdapterBase
{
    public abstract HttpClient Client { get; set; }

    public abstract bool WithAuthentication { get; set; }

    public abstract Task Authenticate(HttpRequestMessage requestMessage);
}
