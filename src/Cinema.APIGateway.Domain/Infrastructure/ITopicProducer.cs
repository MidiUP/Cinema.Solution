using Cinema.APIGateway.Domain.Events;

namespace Cinema.APIGateway.Infrastructure.RabbitMq.Config;

public interface ITopicProducer<T> where T : Event
{
    public Task Produce(T message);
}
 