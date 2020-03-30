using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using BankNet.Domain.BankContext.Entities;
using BankNet.Domain.BankContext.Queries;
using BankNet.Domain.BankContext.Repositories;
using BankNet.Infrastructure.BankNetContext.DataContexts;
using Dapper;

namespace BankNet.Infrastructure.BankNetContext.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {

        private readonly BankNetDataContext context;

        public TransactionRepository(BankNetDataContext context)
            => this.context = context;

        public async Task<IEnumerable<ListTransactionQueryResult>> GetAll()
        {
            const string sql = "SELECT id, accountId, typeTransaction, typeMovement, dateTransaction, value FROM transaction;";
            return await context.connection.QueryAsync<ListTransactionQueryResult>(sql);
        }

        public async Task CreateTransaction(Transaction transaction)
        {
            var sql = $@"INSERT INTO transaction(id, accountId, typeTransaction, typeMovement, dateTransaction, value) VALUES (
                                '{transaction.Id}', '{transaction.AccountId}', {transaction.TypeTransaction.GetHashCode()},
                                {transaction.TypeMovement.GetHashCode()}, '{transaction.DateTransaction:yyyy-MM-dd HH:mm:ss}',
                                {transaction.Value.ToString(CultureInfo.InvariantCulture).Replace(",", ".")});";

            await context.connection.ExecuteAsync(sql);

        }

       
    }
}
