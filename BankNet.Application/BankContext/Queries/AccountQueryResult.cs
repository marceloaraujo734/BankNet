using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace BankNet.Domain.BankContext.Queries
{
    public class AccountQueryResult
    {

        public void ValueSum(decimal value) => Balance += value;

        public void ValueSubtract(decimal value) => Balance -= value;

        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }

    }
}
