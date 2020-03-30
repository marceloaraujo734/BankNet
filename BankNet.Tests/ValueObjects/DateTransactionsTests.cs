using System;
using System.Collections.Generic;
using System.Text;
using BankNet.Domain.BankContext.ValueObjects;
using Xunit;

namespace BankNet.Tests.ValueObjects
{
    public class DateTransactionsTests
    {
        private readonly DateTransaction valiDateTransaction;
        private readonly DateTransaction minDateTransaction;
        private readonly DateTransaction maxDateTransaction;

        public DateTransactionsTests()
        {

            valiDateTransaction = new DateTransaction(DateTime.Now);
            minDateTransaction = new DateTransaction(DateTime.MinValue);
            maxDateTransaction = new DateTransaction(DateTime.MaxValue);            
        }

        [Fact]
        public void ShouldReturnNotificationWhenTheTransactionDateMinDateTransaction()
        {
            Assert.False(minDateTransaction.IsValid);
            Assert.Equal(1, minDateTransaction.Notifications.Count);
        }

        [Fact]
        public void ShouldReturnNotificationWhenTheTransactionDateMaxDateTransaction()
        {
            Assert.False(maxDateTransaction.IsValid);
            Assert.Equal(1, maxDateTransaction.Notifications.Count);
        }

        [Fact]
        public void ShouldReturnNotNotificationWhenDateTransactionIsValid()
        {
            Assert.True(valiDateTransaction.IsValid);
            Assert.Equal(0, valiDateTransaction.Notifications.Count);
        }
    }
}
