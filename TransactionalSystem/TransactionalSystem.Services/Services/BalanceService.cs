using AutoMapper;
using System;
using System.Threading.Tasks;
using TransactionalSystem.Data.Dtos;
using TransactionalSystem.DataAccess.Repositories;
using TransactionalSystem.Shared.Enums;

namespace TransactionalSystem.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly ITransactionsRepository _transactionsRepository;

        public BalanceService(ITransactionsRepository transactionsRepository)
        {
            _transactionsRepository = transactionsRepository;
        }

        public async Task<decimal> GetCurrentAccountBalanceAsync()
        {
            var allTransactions = await _transactionsRepository.GetTransactionsAsync();

            decimal balance = 0;

            foreach(var t in allTransactions)
            {
                if (t.Type.IsCredit())
                {
                    balance -= t.Amount;
                }
                else
                {
                    balance += t.Amount;
                }
            }

            return balance;
        }
    }
}
