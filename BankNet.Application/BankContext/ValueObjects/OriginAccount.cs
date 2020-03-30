using System;
using BankNet.Domain.BankContext.Queries;
using FluentValidator;
using FluentValidator.Validation;

namespace BankNet.Domain.BankContext.ValueObjects
{
    public class OriginAccount : Notifiable
    {

        public OriginAccount(AccountQueryResult account, decimal value)
        {
            this.AccountId = account.Id;

            AddNotifications(new ValidationContract()
                .Requires()
                .AreNotEquals(AccountId, Guid.Empty, "AccountId", "O número da conta de origem não é válido")
                .IsGreaterOrEqualsThan(account.Balance, value, "Value", "O saldo em conta é insuficiente")
            );
        }

        public Guid AccountId { get; set; }


    }
    
}
