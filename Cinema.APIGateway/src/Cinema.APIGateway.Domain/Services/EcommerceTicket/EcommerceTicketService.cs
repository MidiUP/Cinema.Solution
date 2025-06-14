using Cinema.APIGateway.Domain.Exceptions;
using Cinema.APIGateway.Domain.Infrastructure;
using Cinema.APIGateway.Domain.Infrastructure.ApiAdapters;
using Cinema.APIGateway.Domain.Mappers.EcommerceTicket;
using Cinema.APIGateway.Domain.Models.EcommerceTicket;
using Cinema.APIGateway.Domain.Services.EcommerceTicket.Interfaces;
using Cinema.Events;

namespace Cinema.APIGateway.Domain.Services.EcommerceTicket;

public class EcommerceTicketService(ITopicProducer<EcommerceCreateTicketEvent> topicProducer, 
    IEcommerceTicketApiFacade ecommerceTicketHttpAdapter) : IEcommerceTicketService
{
    private readonly ITopicProducer<EcommerceCreateTicketEvent> _topicProducer = topicProducer;
    private readonly IEcommerceTicketApiFacade _ecommerceTicketHttpAdapter = ecommerceTicketHttpAdapter;

    private readonly TimeSpan DEFAULT_TIMEOUT = TimeSpan.FromSeconds(30);

    public async Task AddQueueCheckInMovieAsync(CheckInModel checkInModel)
    {
        var cts = new CancellationTokenSource(DEFAULT_TIMEOUT);

        var validationCheckInModel = checkInModel.Validation();
        if (!validationCheckInModel.IsValid)
            throw new ValidationException(validationCheckInModel.Errors);

        var ecommerceCreateTicketEvent = checkInModel.MapToEcommerceCreateTicketEvent();

        await _topicProducer.ProduceAsync(ecommerceCreateTicketEvent, cts.Token);
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
