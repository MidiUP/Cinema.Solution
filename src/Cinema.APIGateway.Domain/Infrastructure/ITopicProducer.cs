using Cinema.APIGateway.Domain.Events;

namespace Cinema.APIGateway.Domain.Infrastructure;

public interface ITopicProducer<T> where T : Event
{
    public Task ProduceAsync(T message);
}
 