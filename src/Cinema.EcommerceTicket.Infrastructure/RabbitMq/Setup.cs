using Cinema.EcommerceTicket.Domain.Exceptions;
using Cinema.EcommerceTicket.Domain.Shared;
using Cinema.EcommerceTicket.Infrastructure.RabbitMq.Consumers;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Cinema.EcommerceTicket.Infrastructure.RabbitMq;

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
            ConfigureHealthCheck(x);

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(HOST_RABBIMQ, "/", h =>
                {
                    h.Username(HOST_RABBIMQ_USERNAME);
                    h.Password(HOST_RABBIMQ_PASSWORD);
                });

                cfg.UseConsumeFilter(typeof(GlobalExceptionFilter<>), context);

                cfg.UseMessageRetry(r =>
                {
                    r.Exponential(
                        retryLimit: 3,                  // Número de tentativas
                        minInterval: TimeSpan.FromSeconds(10),   // Intervalo inicial
                        maxInterval: TimeSpan.FromSeconds(60),  // Intervalo máximo
                        intervalDelta: TimeSpan.FromSeconds(25)  // Fator de crescimento exponencial
                    );
                    r.Ignore(typeof(CinemaEcommerceTicketException));
                });

                AddConsumer<CreateTicketConsumer>(x, cfg, context, QUEUE_CREATE_ECOMMERCE_TICKET_NAME);
            });
        });
    }

    private static void ConfigureHealthCheck(IBusRegistrationConfigurator x)
    {
        x.ConfigureHealthCheckOptions(options =>
        {
            options.Name = "masstransit";
            options.MinimalFailureStatus = HealthStatus.Unhealthy;
            options.Tags.Add("health");
        });
    }

    private static void AddConsumer<T>(IBusRegistrationConfigurator x, IRabbitMqBusFactoryConfigurator cfg,
        IBusRegistrationContext context,
        string queue) where T : class, IConsumer
    {
        x.AddConsumer<CreateTicketConsumer>();

        cfg.ReceiveEndpoint(queue, e =>
        {
            e.ConfigureConsumer<T>(context);
        });
    }

    private static string GetNameQueue(string queueName)
    {
        return $"{Constants.ENVIRONMENT}.{queueName}";
    }
}
