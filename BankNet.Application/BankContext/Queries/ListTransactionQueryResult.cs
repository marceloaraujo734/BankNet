using System;
using BankNet.Domain.BankContext.Enums;

namespace BankNet.Domain.BankContext.Queries
{
    public class ListTransactionQueryResult
    {
        public Guid TransactionId { get; set; }

        public TypeTransaction Type { get; set; }

        public string Account { get; set; }

        public decimal Value { get; set; }

    }
}
