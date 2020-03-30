using System;
using BankNet.Domain.BankContext.Queries;
using FluentValidator;
using FluentValidator.Validation;

namespace BankNet.Domain.BankContext.ValueObjects
{
    public class DestinyAccount : Notifiable
    {

        public DestinyAccount(Guid accountId)
        {
            this.AccountId = accountId;

            AddNotifications(new ValidationContract()
                .Requires()
                .AreNotEquals(AccountId, Guid.Empty, "AccountId", "O número da conta de origem não é válido")                
            );
        }

        public Guid AccountId { get; set; }


    }
    
}
