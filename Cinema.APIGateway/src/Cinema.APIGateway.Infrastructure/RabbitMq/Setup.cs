using Cinema.APIGateway.Domain.Infrastructure;
using Cinema.APIGateway.Domain.Shared;
using Cinema.APIGateway.Infrastructure.RabbitMq.Config;
using Cinema.Events;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Cinema.APIGateway.Infrastructure.RabbitMq;

public static class Setup
{
    public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
    {
        var rabbitMqOptions = configuration.GetSection("RabbitMq").Get<RabbitMqOptions>()!;
        var queueCreateEcommerceTicketName = GetNameQueue(configuration["ENV"]!, rabbitMqOptions.QueueCreateEcommerceTicketName);
        
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
