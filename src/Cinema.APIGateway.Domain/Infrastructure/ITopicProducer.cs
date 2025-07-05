using Cinema.Events;

namespace Cinema.APIGateway.Domain.Infrastructure;

/// <summary>
/// Interface para produção de mensagens em tópicos de eventos.
/// </summary>
/// <typeparam name="T">Tipo do evento a ser produzido, que deve herdar de <see cref="Event"/>.</typeparam>
/// <remarks>
/// Define o contrato para publicação assíncrona de eventos em sistemas de mensageria, como brokers de mensagens.
/// </remarks>
public interface ITopicProducer<T> where T : Event
{
    /// <summary>
    /// Publica uma mensagem do tipo <typeparamref name="T"/> de forma assíncrona em um tópico.
    /// </summary>
    /// <param name="message">Evento a ser publicado.</param>
    /// <param name="cancellationToken">Token para cancelamento da operação assíncrona.</param>
    /// <returns>Uma tarefa que representa a operação de publicação.</returns>
    public Task ProduceAsync(T message, CancellationToken cancellationToken);
}

