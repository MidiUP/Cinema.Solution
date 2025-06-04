using Cinema.APIGateway.Domain.Infrastructure;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.APIGateway.Infrastructure.RabbitMq.Config;

public class TopicProducer<T> : ITopicProducer<T> where T : Domain.Events.Event
{
    private readonly string _topicName;
    private readonly ISendEndpointProvider _sendEndpointProvider;

    public TopicProducer([FromServices] ISendEndpointProvider sendEndpointProvider, string topicName )
    {
        _topicName = topicName;
        _sendEndpointProvider = sendEndpointProvider;
    }

    public async Task ProduceAsync(T message)
    {
        var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{_topicName}"));
        await endpoint.Send(message);
    }
}
