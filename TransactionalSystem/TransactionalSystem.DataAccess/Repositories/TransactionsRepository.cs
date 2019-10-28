using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TransactionalSystem.Data.Dtos;
using TransactionalSystem.Data.Entities;

namespace TransactionalSystem.DataAccess.Repositories
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly TransactionsDbContext _dbContext;

        private static readonly object _locker = new object();

        public TransactionsRepository(TransactionsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<TransactionDto>> GetTransactionsAsync()
        {
            var entities = await _dbContext.Transactions.ToListAsync();

            var dtos = Mapper.Map<ICollection<TransactionDto>>(entities);
            return dtos;
        }

        public async Task<TransactionDto> GetTransactionByIdAsync(string id)
        {
            var entity = await _dbContext.Transactions.SingleOrDefaultAsync(t =>
                t.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            var dto = Mapper.Map<TransactionDto>(entity);
            return dto;
        }

        public TransactionDto AddTransaction(TransactionDto transactionDto)
        {
            lock (_locker)
            {
                var entity = Mapper.Map<TransactionEntity>(transactionDto);
                entity.Id = Guid.NewGuid().ToString();

                var entry = _dbContext.Transactions.Add(entity);

                _dbContext.SaveChanges();

                var dto = Mapper.Map<TransactionDto>(entry.Entity);
                return dto;
            }
        }
    }
}