using System;
using System.Collections.Generic;
using System.Text;
using BankNet.Domain.BankContext.Enums;
using BankNet.Domain.BankContext.ValueObjects;
using BankNet.Shared.Entities;

namespace BankNet.Domain.BankContext.Entities
{
    public class Transaction : Entity
    {

        public Transaction(OriginAccount account, TypeTransaction typeTransaction, ValueTransaction amount, DateTransaction date)
        {
            this.AccountId = account.AccountId;
            this.TypeTransaction = typeTransaction;
            this.TypeMovement = SetDebit();
            this.DateTransaction = date.Date;    
            this.Value = amount.Value;
        }

        public Transaction(DestinyAccount account, TypeTransaction typeTransaction, ValueTransaction amount, DateTransaction date)
        {
            this.AccountId = account.AccountId;
            this.TypeTransaction = typeTransaction;
            this.TypeMovement = SetCredit();
            this.DateTransaction = date.Date;
            this.Value = amount.Value;
        }

        private TypeMovement SetCredit() => TypeMovement.Credit;

        private TypeMovement SetDebit() => TypeMovement.Debit;

        public Guid AccountId { get; private set; }

        public TypeTransaction TypeTransaction { get; private set; }

        public TypeMovement TypeMovement { get; private set; }

        public DateTime DateTransaction { get; private set; }

        public decimal Value { get; private set; }

    }
}
