using System;
using BankNet.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace BankNet.Domain.BankContext.Commands.TransactionCommands.Request
{
    public class PostTransactionCommand : Notifiable, ICommand
    {
        public string OriginAccount { get; set; }

        public string DestinyAccount { get; set; }

        public DateTime DateTransaction { get; set; }

        public decimal ValueTransaction { get; set; }

        public bool Valid()
        {

            AddNotifications(new ValidationContract()
                .IsNullOrEmpty(OriginAccount, "OriginAccount", "Conta de origem inválida")
                .IsNullOrEmpty(DestinyAccount, "DestinyAccount", "Conta de destino inválida")
                .IsTrue(OriginAccount != DestinyAccount, "Transaction", "A transferência não pode ser realizada, por contas iguais")
                .IsTrue(DateTransaction != DateTime.MinValue, "DateTransaction", "A data informada não é válida")
                .IsTrue(DateTransaction != DateTime.MaxValue, "DateTransaction", "A data informada não é válida")
                .IsTrue(ValueTransaction > 0.00M, "ValueTransaction", "O valor da transação não é válido")
            );
            
           return IsValid;

        }

    }
}
