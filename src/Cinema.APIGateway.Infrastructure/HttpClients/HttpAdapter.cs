using Cinema.APIGateway.Domain.Infrastructure;
using Newtonsoft.Json;
using System.Text.Json;

namespace Cinema.APIGateway.Infrastructure.HttpClients;

public class HttpAdapter
{
    private readonly GatewayAdapterBase? _gatewayAdapter;
    public HttpAdapter() { }

    public HttpAdapter(GatewayAdapterBase gatewayAdapter)
    {
        _gatewayAdapter = gatewayAdapter;
    }

    public async Task<TResponse> GetAsync<TResponse>(HttpClient client, string url, CancellationToken cancellationToken = default)
    {
        // make request
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        //autenticacao
        if (_gatewayAdapter is not null && _gatewayAdapter.WithAuthentication)
            await _gatewayAdapter.Authenticate(request);

        //realizar request
        var response = await client.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();

        //desserializar
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<TResponse>(content);

    }
    public Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException(); // não implementado por questão de tempo, mas seguiria a base do get
    }
    public Task<TResponse> PutAsync<TResponse>(string url, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException(); // não implementado por questão de tempo, mas seguiria a base do get
    }
    public Task<TResponse> DeleteAsync<TResponse>(string url, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException(); // não implementado por questão de tempo, mas seguiria a base do get
    }
}
