

using Cinema.APIGateway.Domain.Shared;
using Microsoft.Extensions.DependencyInjection;
using Polly.Extensions.Http;
using Polly;

namespace Cinema.APIGateway.Infrastructure.HttpClients;

public static class Setup
{
    public static void AddHttpClients(this IServiceCollection services)
    {
        AddEcommerceTicketApiHttpClient(services); 
    }

    private static void AddEcommerceTicketApiHttpClient(IServiceCollection services)
    {
        services.AddHttpClient(Constants.EcommerceTicketApi.NAME, httpClient =>
        {
            httpClient.BaseAddress = new Uri(Constants.EcommerceTicketApi.BASE_URL);
        })
        .AddPolicyHandler(GetRetryPolicy());
    }

    private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(3, attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)));
    }
}
