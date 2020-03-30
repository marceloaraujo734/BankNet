using System;
using System.Threading.Tasks;
using BankNet.Domain.BankContext.Queries;
using BankNet.Domain.BankContext.Repositories;

namespace BankNet.Tests.Fakes
{
    public class FakeAccountsRepository : IAccountRepository
    {
        public AccountQueryResult GetAccount(string accountNumber)
        {
            return new AccountQueryResult
            {
                Id = Guid.NewGuid(),
                ClientId = Guid.NewGuid(),
                AccountNumber = "1234567",
                Balance = 10.5M
            };
        }

        public async Task UpdateBalance(AccountQueryResult account)
        {
            await Task.Delay(1);
        }
    }
}
