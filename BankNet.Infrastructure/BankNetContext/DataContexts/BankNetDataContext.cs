using BankNet.Shared;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace BankNet.Infrastructure.BankNetContext.DataContexts
{
    public class BankNetDataContext : IDisposable
    {

        public MySqlConnection connection { get; set; }

        public BankNetDataContext()
        {
            connection = new MySqlConnection(Settings.ConnectionString);
            connection.Open();
        }

        public void Dispose()
        {
            if (connection.State != ConnectionState.Closed) connection.Close();
        }
    }
}
