using BankNet.Shared;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace BankNet.Infrastructure.BankNetContext.DataContexts
{
    public class BankNetDataContext : IDisposable
    {

        public MySqlConnection Connection { get; set; }

        public BankNetDataContext()
        {
            Connection = new MySqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed) Connection.Close();
        }
    }
}
