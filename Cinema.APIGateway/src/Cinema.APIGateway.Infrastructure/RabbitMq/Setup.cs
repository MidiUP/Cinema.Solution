using Cinema.APIGateway.Domain.Infrastructure;
using Cinema.APIGateway.Domain.Shared;
using Cinema.APIGateway.Infrastructure.RabbitMq.Config;
using Cinema.Domain.Events;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Cinema.APIGateway.Infrastructure.RabbitMq;

public static class Setup
{
    private static readonly string HOST_RABBIMQ = Constants.RabbitMq.RABBIMQ_HOST;
    private static readonly string HOST_RABBIMQ_USERNAME = Constants.RabbitMq.RABBIMQ_USERNAME;
    private static readonly string HOST_RABBIMQ_PASSWORD = Constants.RabbitMq.RABBIMQ_PASSWORD;

    private static readonly string QUEUE_CREATE_ECOMMERCE_TICKET_NAME = GetNameQueue(Constants.RabbitMq.QUEUE_CREATE_ECOMMERCE_TICKET_NAME);

    public static void AddRabbitMq(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.ConfigureHealthCheckOptions(options =>
            {
                options.Name = "masstransit";
                options.MinimalFailureStatus = HealthStatus.Unhealthy;
                options.Tags.Add("health");
            });

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(HOST_RABBIMQ, "/", h =>
                {
                    h.Username(HOST_RABBIMQ_USERNAME);
                    h.Password(HOST_RABBIMQ_PASSWORD);
                });
            });
        });

        // Configura o producer para a fila desejada
        services.AddProducer<EcommerceCreateTicketEvent>(QUEUE_CREATE_ECOMMERCE_TICKET_NAME);
    }

    private static void AddProducer<T>(this IServiceCollection services, string queue) where T : Cinema.Domain.Events.Event
    {
        services.AddScoped<ITopicProducer<T>>(provider => new TopicProducer<T>(provider.GetRequiredService<ISendEndpointProvider>(), queue));
    }

    private static string GetNameQueue(string queueName)
    {
        return $"{Constants.ENVIRONMENT}.{queueName}";
    }
}
