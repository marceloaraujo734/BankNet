using System;
using System.Collections.Generic;
using System.Text;
using BankNet.Shared.Entities;

namespace BankNet.Domain.BankContext.Entities
{
    public class Account : Entity
    {

        public Guid ClientId { get; private set; }

        public string AccountNumber { get; private set; }

        public decimal Balance { get; private set; }

    }

}
