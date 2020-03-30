using System;
using System.Collections.Generic;
using System.Text;
using BankNet.Domain.BankContext.Commands.TransactionCommands.Request;
using Xunit;

namespace BankNet.Tests.Commands
{
    public class PostTransactionCommandTests
    {
        [Fact]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new PostTransactionCommand
            {
                DestinyAccount = "1234567",
                OriginAccount = "7654321",
                ValueTransaction = 10.50M
            };

            Assert.True(command.Valid());
        }

    }
}
