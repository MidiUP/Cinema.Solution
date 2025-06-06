using Cinema.APIGateway.Domain.Events.EcommerceTicket;
using Cinema.APIGateway.Domain.Exceptions;
using Cinema.APIGateway.Domain.Infrastructure;
using Cinema.APIGateway.Domain.Mappers.EcommerceTicket;
using Cinema.APIGateway.Domain.Models.EcommerceTicket;
using Cinema.APIGateway.Domain.Services.EcommerceTicket.Interfaces;
using Microsoft.Extensions.Logging;
using TimeoutException = Cinema.APIGateway.Domain.Exceptions.TimeoutException;

namespace Cinema.APIGateway.Domain.Services.EcommerceTicket;

public class EcommerceTicketService(ITopicProducer<EcommerceCreateTicketEvent> topicProducer, ILogger<EcommerceTicketService> logger) : IEcommerceTicketService
{
    private readonly ITopicProducer<EcommerceCreateTicketEvent> _topicProducer = topicProducer;
    private readonly ILogger<EcommerceTicketService> _logger = logger;
    public async Task AddQueueCheckInMovieAsync(CheckInModel checkInModel)
    {
        try
        {
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));

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
}
