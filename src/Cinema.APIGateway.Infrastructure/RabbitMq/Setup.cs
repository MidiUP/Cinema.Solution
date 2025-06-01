using Microsoft.Extensions.DependencyInjection;
using MassTransit;
using Cinema.APIGateway.Domain.Shared;
using Cinema.APIGateway.Infrastructure.RabbitMq.Config;
using Cinema.APIGateway.Domain.Services.Catalog.Interfaces;

namespace Cinema.APIGateway.Infrastructure.RabbitMq;

public static class Setup
{
    private static readonly string HOST_RABBIMQ = Constants.RabbitMq.RABBIMQ_HOST;
    private static readonly string RABBIMQ_PORT = Constants.RabbitMq.RABBIMQ_PORT;
    private static readonly string HOST_RABBIMQ_USERNAME = Constants.RabbitMq.RABBIMQ_USERNAME;
    private static readonly string HOST_RABBIMQ_PASSWORD = Constants.RabbitMq.RABBIMQ_PASSWORD;

    private static readonly string QUEUE_CREATE_ECOMMERCE_TICKET_NAME = Constants.RabbitMq.QUEUE_CREATE_ECOMMERCE_TICKET_NAME;

    public static void AddRabbitMq(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(HOST_RABBIMQ, RABBIMQ_PORT, h =>
                {
                    h.Username(HOST_RABBIMQ_USERNAME);
                    h.Password(HOST_RABBIMQ_PASSWORD);
                });
            });
        });

        // Configura o producer para a fila desejada
        services.AddProducer<Domain.Events.Event>(QUEUE_CREATE_ECOMMERCE_TICKET_NAME);
    }

    private static void AddProducer<T>(this IServiceCollection services, string queue) where T : Domain.Events.Event
    {
        services.AddScoped<ITopicProducer<T>>(provider => new TopicProducer<T>(provider.GetRequiredService<ISendEndpointProvider>(), queue));
    }
}
