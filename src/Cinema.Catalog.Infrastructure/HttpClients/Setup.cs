using Cinema.Catalog.Domain.Shared;
using Cinema.Catalog.Infrastructure.HttpClients.GatewayAdapters;
using Cinema.Catalog.Infrastructure.HttpClients.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;

namespace Cinema.Catalog.Infrastructure.HttpClients;

public static class Setup
{
    public static void AddHttpClients(this IServiceCollection services)
    {
        services.AddTmdbApiApiHttpClient();
        services.AddHandlersHttp();
        services.AddGateways();
    }

    private static void AddTmdbApiApiHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient(Constants.TmdbApi.NAME, httpClient =>
        {
            httpClient.BaseAddress = new Uri(Constants.TmdbApi.BASE_URL);
        })
        .AddPolicyHandler(GetRetryPolicy())
        .AddHttpMessageHandler<AuthenticateCustomHandler<AuthBasicImdb>>();
    }

    private static void AddGateways(this IServiceCollection services)
    {
        services.AddTransient<AuthBasicImdb>();
    }

    private static void AddHandlersHttp(this IServiceCollection services)
    {
        services.AddTransient<AuthenticateCustomHandler<AuthBasicImdb>>();
    }

    private static AsyncRetryPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(3, attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)));
    }
}
