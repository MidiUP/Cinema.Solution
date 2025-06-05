using Cinema.APIGateway.Domain.Events.EcommerceTicket;
using Cinema.APIGateway.Domain.Exceptions;
using Cinema.APIGateway.Domain.Infrastructure;
using Cinema.APIGateway.Domain.Mappers.EcommerceTicket;
using Cinema.APIGateway.Domain.Models.EcommerceTicket;
using Cinema.APIGateway.Domain.Services.EcommerceTicket.Interfaces;

namespace Cinema.APIGateway.Domain.Services.EcommerceTicket;

public class EcommerceTicketService(ITopicProducer<EcommerceCreateTicketEvent> topicProducer) : IEcommerceTicketService
{
    private readonly ITopicProducer<EcommerceCreateTicketEvent> _topicProducer = topicProducer;
    public async Task AddQueueCheckInMovieAsync(CheckInModel checkInModel)
    {
        var validationCheckInModel = checkInModel.Validation();
        if (!validationCheckInModel.IsValid)
            throw new ValidationException(validationCheckInModel.Errors);

        var ecommerceCreateTicketEvent = checkInModel.MapToEcommerceCreateTicketEvent();

        await _topicProducer.ProduceAsync(ecommerceCreateTicketEvent);
    }
}
