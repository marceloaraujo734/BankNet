using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BankNet.Domain.BankContext.Queries;

namespace BankNet.Domain.BankContext.Repositories
{
    public interface IAccountRepository
    {

        Task UpdateBalance(AccountQueryResult account);

        AccountQueryResult GetAccount(string accountNumber);

    }
}
