using System;
using System.Globalization;
using System.Threading.Tasks;
using BankNet.Domain.BankContext.Queries;
using BankNet.Domain.BankContext.Repositories;
using BankNet.Infrastructure.BankNetContext.DataContexts;
using Dapper;

namespace BankNet.Infrastructure.BankNetContext.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public AccountRepository(BankNetDataContext context)
            => this.context = context;
        
        private readonly BankNetDataContext context;

        public AccountQueryResult GetAccount(string accountNumber)
        {
            var sql = $"SELECT id, clientId, accountNumber, balance FROM account WHERE accountNumber = '{accountNumber}';";

            return context.Connection.QueryFirstOrDefault<AccountQueryResult>(sql);
        }

        public async Task UpdateBalance(AccountQueryResult account)
        {
            try
            {
                var sql = $"UPDATE account SET balance = {account.Balance.ToString(CultureInfo.InvariantCulture).Replace(",", ".")} WHERE id = '{account.Id}';";

                await context.Connection.ExecuteAsync(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }


            
        }
    }
}
