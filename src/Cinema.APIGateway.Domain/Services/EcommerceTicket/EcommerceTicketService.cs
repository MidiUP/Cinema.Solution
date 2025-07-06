using Cinema.APIGateway.Domain.Exceptions;
using Cinema.APIGateway.Domain.Infrastructure;
using Cinema.APIGateway.Domain.Infrastructure.ApiFacades;
using Cinema.APIGateway.Domain.Mappers.EcommerceTicket;
using Cinema.APIGateway.Domain.Models.EcommerceTicket;
using Cinema.APIGateway.Domain.Services.EcommerceTicket.Interfaces;
using Cinema.Events;

namespace Cinema.APIGateway.Domain.Services.EcommerceTicket;

/// <summary>
/// Serviço de domínio responsável pelas operações de e-commerce de tickets de cinema.
/// </summary>
/// <remarks>
/// Implementa a lógica de negócio para registrar check-in de ingressos na fila de processamento e consultar tickets, 
/// integrando-se com sistemas de mensageria e APIs externas de e-commerce de ingressos.
/// </remarks>
public class EcommerceTicketService(ITopicProducer<EcommerceCreateTicketEvent> topicProducer,
    IEcommerceTicketApiFacade ecommerceTicketHttpAdapter) : IEcommerceTicketService
{
    private readonly ITopicProducer<EcommerceCreateTicketEvent> _topicProducer = topicProducer;
    private readonly IEcommerceTicketApiFacade _ecommerceTicketApiFacade = ecommerceTicketHttpAdapter;

    private readonly TimeSpan DEFAULT_TIMEOUT = TimeSpan.FromSeconds(15);

    /// <summary>
    /// Adiciona um novo check-in de ingresso na fila para processamento.
    /// </summary>
    /// <param name="checkInModel">Modelo contendo os dados do check-in a ser registrado.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    /// <exception cref="ValidationException">Lançada quando os dados do check-in são inválidos.</exception>
    public async Task AddQueueCheckInMovieAsync(CheckInModel checkInModel)
    {
        var cts = new CancellationTokenSource(DEFAULT_TIMEOUT);

        var validationCheckInModel = checkInModel.Validation();
        if (!validationCheckInModel.IsValid)
            throw new ValidationException(validationCheckInModel.Errors);

        var ecommerceCreateTicketEvent = checkInModel.MapToEcommerceCreateTicketEvent();

        await _topicProducer.ProduceAsync(ecommerceCreateTicketEvent, cts.Token);
    }

    /// <summary>
    /// Obtém todos os tickets de ingresso disponíveis.
    /// </summary>
    /// <returns>Uma coleção de <see cref="TicketModel"/> representando os tickets encontrados.</returns>
    public async Task<IEnumerable<TicketModel>> GetTicketsAsync()
    {
        var cts = new CancellationTokenSource(DEFAULT_TIMEOUT);
        return await _ecommerceTicketApiFacade.GetTicketsAsync(cts.Token);
    }

    /// <summary>
    /// Obtém todos os tickets de ingresso associados a um cliente específico.
    /// </summary>
    /// <param name="customerId">Identificador do cliente.</param>
    /// <returns>Uma coleção de <see cref="TicketModel"/> representando os tickets do cliente informado.</returns>
    public async Task<IEnumerable<TicketModel>> GetTicketsByCustomerIdAsync(int customerId)
    {
        var cts = new CancellationTokenSource(DEFAULT_TIMEOUT);
        return await _ecommerceTicketApiFacade.GetTicketsByCustomerIdAsync(customerId, cts.Token);
    }
}

