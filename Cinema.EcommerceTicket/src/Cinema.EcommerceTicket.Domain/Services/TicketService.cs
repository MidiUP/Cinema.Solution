using Cinema.EcommerceTicket.Domain.Exceptions;
using Cinema.EcommerceTicket.Domain.Infrastructure.Repositories;
using Cinema.EcommerceTicket.Domain.Models;
using Cinema.EcommerceTicket.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Cinema.EcommerceTicket.Domain.Services;

public class TicketService(ILogger<TicketService> logger, ITicketRepository ticketRepository) : ITicketService
{
    private readonly ILogger<TicketService> _logger = logger;
    private readonly ITicketRepository _ticketRepository = ticketRepository;

    public async Task CreateTicketAsync(TicketModel ticketModel)
    {
        
        //validar se filme existe

        //lógica para calcular preço seria aplicada aqui
        ticketModel.Price = 20.00m;
        ticketModel.CreatedAt = DateTime.Now;

        var validationModel = ticketModel.Validation();
        if(!validationModel.IsValid)
        {
            _logger.LogWarning("Erro ao validar o ticket: {Errors}", validationModel.Errors);
            throw new ValidationException(validationModel.Errors);
        }

        await _ticketRepository.CreateTicketAsync(ticketModel);
    }

    public async Task<IEnumerable<TicketModel>> GetTicketsByCostumerAsync(int customerId)
    {
        return await _ticketRepository.GetTicketsByCustomerAsync(customerId);
    }
}
