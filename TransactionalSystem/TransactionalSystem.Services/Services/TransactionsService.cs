using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionalSystem.Data.Dtos;
using TransactionalSystem.DataAccess.Repositories;
using TransactionalSystem.Services.Exceptions;
using TransactionalSystem.Services.Models;
using TransactionalSystem.Services.Models.CreateTransaction;
using TransactionalSystem.Shared.Enums;

namespace TransactionalSystem.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IBalanceService _balanceService;

        public TransactionsService(ITransactionsRepository transactionsRepository, IBalanceService balanceService)
        {
            _transactionsRepository = transactionsRepository;
            _balanceService = balanceService;
        }

        public async Task<ICollection<TransactionDetailsModel>> GetAllTransactionsAsync()
        {
            var transactions = await _transactionsRepository.GetTransactionsAsync();

            var models = Mapper.Map<ICollection<TransactionDetailsModel>>(transactions);

            return models;
        }

        public async Task<TransactionDetailsModel> GetTransactionByIdAsync(string id)
        {
            var transaction = await _transactionsRepository.GetTransactionByIdAsync(id);

            var model = Mapper.Map<TransactionDetailsModel>(transaction);

            return model;
        }

        public async Task<TransactionDetailsModel> CreateTransactionAsync(CreateTransactionModel transaction)
        {
            if (await IsEnoughBalanceAsync(transaction) == false)
            {
                throw new CreateTransactionException(CreateTransactionErrors.NotEnoughBalance);
            }

            var transactionDto = Mapper.Map<TransactionDto>(transaction);

            transactionDto.Occured = DateTime.UtcNow;

            var entity = _transactionsRepository.AddTransaction(transactionDto);

            var mappedEntity = Mapper.Map<TransactionDetailsModel>(entity);

            return mappedEntity;
        }

        private async Task<bool> IsEnoughBalanceAsync(CreateTransactionModel transaction)
        {
            if (transaction.Type.IsCredit())
            {
                var currentBalance = await _balanceService.GetCurrentAccountBalanceAsync();
                if (currentBalance < transaction.Amount)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
