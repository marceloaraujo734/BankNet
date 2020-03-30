using System;
using System.Collections.Generic;
using System.Text;
using FluentValidator;
using FluentValidator.Validation;

namespace BankNet.Domain.BankContext.ValueObjects
{
    public class DateTransaction : Notifiable
    {
        public DateTransaction(DateTime dateTransaction)
        {
            Date = dateTransaction;

            AddNotifications(new ValidationContract()
                .Requires()
                .IsTrue(Date != DateTime.MinValue, "Date", "A data da transação não é válida")
                .IsTrue(Date != DateTime.MaxValue, "Date", "A data da transação não é válida")                
            );
        }


        public DateTime Date { get; set; }

    }
}
