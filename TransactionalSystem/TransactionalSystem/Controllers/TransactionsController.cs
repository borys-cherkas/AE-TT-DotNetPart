using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransactionalSystem.Models.Transactions;
using TransactionalSystem.Services;
using TransactionalSystem.Services.Exceptions;
using TransactionalSystem.Services.Models.CreateTransaction;

namespace TransactionalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsService _transactionsService;

        public TransactionsController(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }

        // GET api/transactions
        [HttpGet]
        public async Task<ActionResult<GetTransactionsListResponse>> Get()
        {
            var transactionList = await _transactionsService.GetAllTransactionsAsync();

            var transactionItemsList = Mapper.Map<ICollection<TransactionItem>>(transactionList);

            return Ok(new GetTransactionsListResponse(transactionItemsList));
        }

        // GET api/transactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetTransactionResponse>> Get(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out Guid _))
            {
                return BadRequest("invalid ID supplied");
            }

            var transaction = await _transactionsService.GetTransactionByIdAsync(id);
            if (transaction == null)
            {
                return NotFound("transaction not found");
            }

            var transactionItem = Mapper.Map<TransactionItem>(transaction);

            return Ok(new GetTransactionResponse(transactionItem));
        }

        // POST api/transactions
        [HttpPost]
        public async Task<ActionResult<CreateTransactionResponse>> Post([FromBody] CreateTransactionRequest model)
        {
            var serviceModel = Mapper.Map<CreateTransactionModel>(model);

            try
            {
                var transaction = await _transactionsService.CreateTransactionAsync(serviceModel);

                var transactionItem = Mapper.Map<TransactionItem>(transaction);

                return Ok(new CreateTransactionResponse(transactionItem));
            }
            catch (CreateTransactionException ex)
            {
                if (ex.Error == CreateTransactionErrors.NotEnoughBalance)
                {
                    return BadRequest("Balance is low");
                }

                throw;
            }
        }
    }
}
