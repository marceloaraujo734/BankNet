using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using BankNet.Domain.BankContext.Entities;
using BankNet.Domain.BankContext.Queries;
using BankNet.Domain.BankContext.Repositories;

namespace BankNet.Tests.Fakes
{
    public class FakeTransactionRepository : ITransactionRepository
    {
        public async Task CreateTransaction(Transaction transaction)
        {
            await Task.Delay(10);
        }

        public async Task<IEnumerable<ListTransactionQueryResult>> GetAll()
        {
            return await Task.FromResult(default(IEnumerable<ListTransactionQueryResult>));
        }
    }
}
