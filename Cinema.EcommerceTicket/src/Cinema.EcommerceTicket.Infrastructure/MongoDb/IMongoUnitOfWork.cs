using MongoDB.Driver;

namespace Cinema.EcommerceTicket.Domain.Infrastructure
{
    public interface IMongoUnitOfWork
    {
        IClientSessionHandle Session { get; }
        Task StartTransactionAsync();
        Task CommitAsync();
        Task AbortAsync();
    }
}
