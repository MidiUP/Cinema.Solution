

using Cinema.APIGateway.Domain.Shared;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;

namespace Cinema.APIGateway.Infrastructure.HttpClients;

public static class Setup
{
    public static void AddHttpClients(this IServiceCollection services)
    {
        services.AddEcommerceTicketApiHttpClient();
        services.AddCatalogApiHttpClient();
    }

    private static void AddEcommerceTicketApiHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient(Constants.EcommerceTicketApi.NAME, httpClient =>
        {
            httpClient.BaseAddress = new Uri(Constants.EcommerceTicketApi.BASE_URL);
        })
        .AddPolicyHandler(GetRetryPolicy());
    }

    private static void AddCatalogApiHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient(Constants.CatalogApi.NAME, httpClient =>
        {
            httpClient.BaseAddress = new Uri(Constants.CatalogApi.BASE_URL);
        })
        .AddPolicyHandler(GetRetryPolicy());
    }

    private static AsyncRetryPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(3, attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)));
    }
}
