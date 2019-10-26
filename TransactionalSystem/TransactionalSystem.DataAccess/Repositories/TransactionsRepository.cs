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
        private bool _acquiredLock = false;

        public TransactionsRepository(TransactionsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<TransactionDto>> GetTransactionsAsync()
        {
            if (_acquiredLock)
            {
                Monitor.Wait(_locker);
            }

            var entities = await _dbContext.Transactions.ToListAsync();

            var dtos = Mapper.Map<ICollection<TransactionDto>>(entities);
            return dtos;
        }

        public async Task<TransactionDto> GetTransactionByIdAsync(string id)
        {
            if (_acquiredLock)
            {
                Monitor.Wait(_locker);
            }

            var entity = await _dbContext.Transactions.SingleOrDefaultAsync(t =>
                t.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            var dto = Mapper.Map<TransactionDto>(entity);
            return dto;
        }

        public async Task<TransactionDto> AddTransactionAsync(TransactionDto transactionDto)
        {
            try
            {
                Monitor.Enter(_locker, ref _acquiredLock);

                var entity = Mapper.Map<TransactionEntity>(transactionDto);
                entity.Id = Guid.NewGuid().ToString();

                var entry = await _dbContext.Transactions.AddAsync(entity);

                await _dbContext.SaveChangesAsync();

                var dto = Mapper.Map<TransactionDto>(entry.Entity);
                return dto;
            }
            finally
            {
                if (_acquiredLock)
                {
                    Monitor.Exit(_locker);
                    _acquiredLock = false;
                }
            }
        }
    }
}
