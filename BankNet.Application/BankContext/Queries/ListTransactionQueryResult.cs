using System;
using BankNet.Domain.BankContext.Enums;

namespace BankNet.Domain.BankContext.Queries
{
    public class ListTransactionQueryResult
    {
        public Guid Id { get; set; }

        public Guid AccountId { get; set; }

        public TypeTransaction TypeTransaction { get; set; }

        public TypeMovement TypeMovement { get; set; }

        public DateTime DateTransaction { get; set; }

        public decimal Value { get; set; }

    }
}
