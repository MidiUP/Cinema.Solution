using Cinema.APIGateway.Domain.Infrastructure;
using Cinema.APIGateway.Domain.Shared;
using Cinema.APIGateway.Infrastructure.RabbitMq.Config;
using Cinema.Events;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using RabbitMQ.Client;

namespace Cinema.APIGateway.Infrastructure.RabbitMq;

public static class Setup
{
    public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
    {
        var rabbitMqOptions = configuration.GetSection("RabbitMq").Get<RabbitMqOptions>()!;
        var queueCreateEcommerceTicketName = GetNameQueue(Domain.Shared.Constants.ENV, rabbitMqOptions.QueueCreateEcommerceTicketName);

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
                cfg.Host(rabbitMqOptions.Host, "/", h =>
                {
                    h.Username(rabbitMqOptions.Username);
                    h.Password(rabbitMqOptions.Password);
                });
            });
        });

        // Configura o producer para a fila desejada
        services.AddProducer<EcommerceCreateTicketEvent>(queueCreateEcommerceTicketName);

        services.AddHealthChecks()
        .AddRabbitMQ(async s =>
        {
            var factory = new ConnectionFactory
            {
                HostName = rabbitMqOptions.Host,
                UserName = rabbitMqOptions.Username,
                Password = rabbitMqOptions.Password,
                Port = int.TryParse(rabbitMqOptions.Port, out var port) ? port : AmqpTcpEndpoint.UseDefaultPort
            };
            return await factory.CreateConnectionAsync();
        },
        name: "RabbitMQ",
        failureStatus: HealthStatus.Unhealthy,
        tags: new[] { "health" }
        );
    }

    private static void AddProducer<T>(this IServiceCollection services, string queue) where T : Events.Event
    {
        services.AddScoped<ITopicProducer<T>>(provider => new TopicProducer<T>(provider.GetRequiredService<ISendEndpointProvider>(), queue));
    }

    private static string GetNameQueue(string env, string queueName)
    {
        return $"{env}.{queueName}";
    }
}
