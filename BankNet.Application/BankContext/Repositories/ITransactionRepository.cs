using System.Collections.Generic;
using System.Threading.Tasks;
using BankNet.Domain.BankContext.Entities;
using BankNet.Domain.BankContext.Queries;

namespace BankNet.Domain.BankContext.Repositories
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<ListTransactionQueryResult>> GetAll();

        Task CreateTransaction(Transaction transaction);

    }
}
