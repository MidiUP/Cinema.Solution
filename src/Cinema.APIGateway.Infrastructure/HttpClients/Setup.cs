using Cinema.APIGateway.Domain.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;

namespace Cinema.APIGateway.Infrastructure.HttpClients;

public static class Setup
{
    public static void AddHttpClients(this IServiceCollection services, IConfiguration configuration)
    {
        var ecommerceOptions = configuration.GetSection("EcommerceTicketApi").Get<EcommerceTicketApiOptions>()!;
        var catalogOptions = configuration.GetSection("CatalogApi").Get<CatalogApiOptions>()!;

        services.AddEcommerceTicketApiHttpClient(ecommerceOptions);
        services.AddCatalogApiHttpClient(catalogOptions);
    }

    private static void AddEcommerceTicketApiHttpClient(this IServiceCollection services, EcommerceTicketApiOptions options)
    {
        services.AddHttpClient(options.Name, httpClient =>
        {
            httpClient.BaseAddress = new Uri(options.BaseUrl);
        })
        .AddPolicyHandler(GetRetryPolicy());
    }

    private static void AddCatalogApiHttpClient(this IServiceCollection services, CatalogApiOptions options)
    {
        services.AddHttpClient(options.Name, httpClient =>
        {
            httpClient.BaseAddress = new Uri(options.BaseUrl);
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
