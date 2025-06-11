using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
