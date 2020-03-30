using System;
using System.Collections.Generic;
using System.Text;
using FluentValidator;
using FluentValidator.Validation;

namespace BankNet.Domain.BankContext.ValueObjects
{
    public class ValueTransaction : Notifiable
    {

        public ValueTransaction(decimal value)
        {
            this.Value = value;

            AddNotifications(new ValidationContract()
                .Requires()
                .IsGreaterThan(Value, 0.00, "Value", "O valor informado não é válido")
            );
        }

        public decimal Value { get; private set; }
        
    }
}
