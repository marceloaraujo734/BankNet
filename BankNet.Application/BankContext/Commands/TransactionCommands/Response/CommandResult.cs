﻿using BankNet.Shared.Commands;

namespace BankNet.Domain.BankContext.Commands.TransactionCommands.Response
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool success, string message, object data = null)
        {
            this.Success = success;
            this.Message = message;
            this.Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
