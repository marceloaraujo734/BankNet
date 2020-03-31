using System.Collections.Generic;
using System.Threading.Tasks;
using BankNet.Domain.BankContext.Commands.TransactionCommands.Request;
using BankNet.Domain.BankContext.Commands.TransactionCommands.Response;
using BankNet.Domain.BankContext.Handlers;
using BankNet.Domain.BankContext.Queries;
using BankNet.Domain.BankContext.Repositories;
using BankNet.Shared.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankNet.Api.Controllers.v1
{
    /// <summary>
    /// 
    /// </summary>
    //[Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository repository;
        private readonly TransactionHandler handler;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="handler"></param>
        public TransactionController(ITransactionRepository repository, TransactionHandler handler)
        {
            this.repository = repository;
            this.handler = handler;
        }

        /// <summary>
        /// Realiza a transferência entre contas
        /// </summary>
        /// <remarks>
        /// Realiza a transferência de acordo com os valores informados.
        ///
        ///     Request:
        ///     POST /v1/transfer
        ///     {
        ///        "destinyaccount": "1234567",
        ///        "originaccount": "7654321",
        ///        "dateTransaction": "2020-03-30T01:47:51.630Z", 
        ///        "valuetransaction": 10.50
        ///     }
        /// 
        ///     Response:
        ///     {
        ///        "success": true,
        ///        "data": "Transferência realizado com sucesso!"
        ///     }
        ///     
        ///
        /// </remarks>
        /// <response code="200">Transferência realizado com sucesso!</response>
        /// <param name="command">Dados da operação de transferência bancária.</param>
        /// <returns>Retorna mensagem de sucessso</returns>
        [HttpPost]
        [Route("Transfer")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ICommandResult> Post([FromBody]PostTransactionCommand command)
            => await handler.Handle(command);

        /// <summary>
        /// Obtém todas as transações
        /// </summary>
        /// <returns>Retorna todas as transações</returns>
        [HttpGet]
        [Route("GetAll")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<ListTransactionQueryResult>> GetAll()
            => await repository.GetAll(); 

    }
}
