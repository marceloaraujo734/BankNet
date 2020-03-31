
using System;
using BankNet.Domain.BankContext.Commands.TransactionCommands.Request;
using BankNet.Domain.BankContext.Handlers;
using BankNet.Tests.Fakes;
using Xunit;

namespace BankNet.Tests.Handlers
{
    public class TransactionHandlerTests
    {

        [Fact]
        public void ShouldRegisterTransferWhenCommandIsValid()
        {
            var command = new PostTransactionCommand
            {
                DestinyAccount = "1234567",
                OriginAccount = "7654321",
                DateTransaction = DateTime.Now,
                ValueTransaction = 10.50M
            };

            var handler = new TransactionHandler(new FakeTransactionRepository(), new FakeAccountsRepository());
            
            var result = handler.Handle(command);

            Assert.NotNull(result);
            Assert.True(handler.IsValid);

        }

    }
}
