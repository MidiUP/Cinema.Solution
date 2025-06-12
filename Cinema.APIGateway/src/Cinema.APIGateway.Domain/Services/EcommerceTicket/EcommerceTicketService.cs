using Cinema.Domain.Events;
using Cinema.APIGateway.Domain.Exceptions;
using Cinema.APIGateway.Domain.Infrastructure;
using Cinema.APIGateway.Domain.Mappers.EcommerceTicket;
using Cinema.APIGateway.Domain.Models.EcommerceTicket;
using Cinema.APIGateway.Domain.Services.EcommerceTicket.Interfaces;
using Microsoft.Extensions.Logging;
using TimeoutException = Cinema.APIGateway.Domain.Exceptions.TimeoutException;
using Cinema.APIGateway.Domain.Infrastructure.ApiAdapters;

namespace Cinema.APIGateway.Domain.Services.EcommerceTicket;

public class EcommerceTicketService(ITopicProducer<EcommerceCreateTicketEvent> topicProducer, ILogger<EcommerceTicketService> logger, 
    IEcommerceTicketApiFacade ecommerceTicketHttpAdapter) : IEcommerceTicketService
{
    private readonly ITopicProducer<EcommerceCreateTicketEvent> _topicProducer = topicProducer;
    private readonly IEcommerceTicketApiFacade _ecommerceTicketHttpAdapter = ecommerceTicketHttpAdapter;
    private readonly ILogger<EcommerceTicketService> _logger = logger;

    private readonly TimeSpan DEFAULT_TIMEOUT = TimeSpan.FromSeconds(30);

    public async Task AddQueueCheckInMovieAsync(CheckInModel checkInModel)
    {
        try
        {
            var cts = new CancellationTokenSource(DEFAULT_TIMEOUT);

            var validationCheckInModel = checkInModel.Validation();
            if (!validationCheckInModel.IsValid)
                throw new ValidationException(validationCheckInModel.Errors);

            var ecommerceCreateTicketEvent = checkInModel.MapToEcommerceCreateTicketEvent();

            await _topicProducer.ProduceAsync(ecommerceCreateTicketEvent, cts.Token);
        }
        catch (OperationCanceledException)
        {
            _logger.LogError("Erro de timeout ao adicionar mensagem de checkin na fila");
            throw new TimeoutException();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro desconhecido ao adicionar mensagem de checkin na fila");
            throw;
        }
    }

    public async Task<IEnumerable<TicketModel>> GetTicketsAsync()
    {
        var cts = new CancellationTokenSource(DEFAULT_TIMEOUT);
        return await _ecommerceTicketHttpAdapter.GetTicketsAsync(cts.Token);
    }

    public async Task<IEnumerable<TicketModel>> GetTicketsByCustomerIdAsync(int customerId)
    {
        var cts = new CancellationTokenSource(DEFAULT_TIMEOUT);
        return await _ecommerceTicketHttpAdapter.GetTicketsByCustomerIdAsync(customerId, cts.Token);
    }
}
