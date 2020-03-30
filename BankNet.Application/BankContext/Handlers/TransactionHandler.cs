using System;
using System.Threading.Tasks;
using BankNet.Domain.BankContext.Commands.TransactionCommands.Request;
using BankNet.Domain.BankContext.Commands.TransactionCommands.Response;
using BankNet.Domain.BankContext.Entities;
using BankNet.Domain.BankContext.Enums;
using BankNet.Domain.BankContext.Queries;
using BankNet.Domain.BankContext.Repositories;
using BankNet.Domain.BankContext.ValueObjects;
using BankNet.Shared.Commands;
using FluentValidator;

namespace BankNet.Domain.BankContext.Handlers
{
    public class TransactionHandler : Notifiable, ICommandHandler<PostTransactionCommand>
    {

        private readonly ITransactionRepository transactionRepository;
        private readonly IAccountRepository accountRepository;

        public TransactionHandler(ITransactionRepository transactionRepository, IAccountRepository accountRepository)
        {
            this.transactionRepository = transactionRepository;
            this.accountRepository = accountRepository;
        }

        public async Task<ICommandResult> Handle(PostTransactionCommand command)
        {
            try
            {

                var resultOriginAccount = accountRepository.GetAccount(command.OriginAccount);
                var resultDestinyAccount = accountRepository.GetAccount(command.DestinyAccount);

                var originAccount = new OriginAccount(resultOriginAccount, command.ValueTransaction);
                var destinyAccount = new DestinyAccount(resultDestinyAccount.Id);
                var dateTransaction = new DateTransaction(command.DateTransaction);
                var valueTransaction = new ValueTransaction(command.ValueTransaction);

                AddNotifications(destinyAccount.Notifications);
                AddNotifications(originAccount.Notifications);
                AddNotifications(dateTransaction.Notifications);
                AddNotifications(valueTransaction.Notifications);

                if (Invalid) return new CommandResult(false, "Por favor, corrija os valores abaixo:", Notifications);

                await CreateTransaction(originAccount, destinyAccount, valueTransaction, dateTransaction);

                await ChangeBalanceOriginAccount(resultOriginAccount, valueTransaction);
                await ChangeBalanceDestinyAccount(resultDestinyAccount, valueTransaction);

                return new CommandResult(true, "Transferência realizado com sucesso!");

            }
            catch (Exception ex)
            {
                return new CommandResult(false, ex.Message, ex);
            }
        }

        private async Task CreateTransaction(OriginAccount originAccount, DestinyAccount destinyAccount, ValueTransaction valueTransaction, DateTransaction dateTransaction)
        {
            var originAccountTransfer = new Transaction(originAccount, TypeTransaction.Transfer, valueTransaction, dateTransaction);
            var destinyAccountTransfer = new Transaction(destinyAccount, TypeTransaction.Transfer, valueTransaction, dateTransaction);

            await transactionRepository.CreateTransaction(originAccountTransfer);
            await transactionRepository.CreateTransaction(destinyAccountTransfer);
        }

        private async Task ChangeBalanceOriginAccount(AccountQueryResult result, ValueTransaction valueTransaction)
        {
            result.ValueSubtract(valueTransaction.Value);

            await accountRepository.UpdateBalance(result);
        }

        private async Task ChangeBalanceDestinyAccount(AccountQueryResult result, ValueTransaction valueTransaction)
        {
            result.ValueSum(valueTransaction.Value);

            await accountRepository.UpdateBalance(result);
        }

    }
}
