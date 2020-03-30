﻿using System;
using System.Collections.Generic;
using System.Text;
using BankNet.Shared.Commands;

namespace BankNet.Domain.BankContext.Commands.TransactionCommands.Response
{
    public class PostTransactionCommandResult : ICommandResult
    {
        public PostTransactionCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
