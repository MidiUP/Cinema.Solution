using Cinema.EcommerceTicket.Domain.Infrastructure;
using Cinema.EcommerceTicket.Domain.Infrastructure.Repositories;
using Cinema.EcommerceTicket.Domain.Models;
using Cinema.EcommerceTicket.Domain.Shared;
using MongoDB.Driver;

namespace Cinema.EcommerceTicket.Infrastructure.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly IMongoUnitOfWork _unitOfWork;
    private readonly IMongoCollection<TicketModel> _ticketCollection;
    private readonly string COLLECTION_NAME = Constants.MongoDb.MONGODB_TICKETS_COLLECTION_NAME;

    public TicketRepository(IMongoUnitOfWork unitOfWork, IMongoDatabase database)
    {
        _unitOfWork = unitOfWork;
        _ticketCollection = database.GetCollection<TicketModel>(COLLECTION_NAME);
    }
    public async Task CreateTicketAsync(TicketModel ticketModel)
    {
        //await _unitOfWork.StartTransactionAsync();
        try
        {
            await _ticketCollection.InsertOneAsync(ticketModel);
            //await _unitOfWork.CommitAsync();
        }
        catch
        {
            //await _unitOfWork.AbortAsync();
            throw;
        }
    }

    public async Task<IEnumerable<TicketModel>> GetTicketsByCustomerAsync(int customerId)
    {
        var filter = Builders<TicketModel>.Filter.Eq(t => t.CustomerId, customerId);
        var result = await _ticketCollection.FindAsync(filter);
        return await result.ToListAsync();
    }
}
