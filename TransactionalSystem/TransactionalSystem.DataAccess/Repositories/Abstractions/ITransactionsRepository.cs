using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionalSystem.Data.Dtos;

namespace TransactionalSystem.DataAccess.Repositories
{
    public interface ITransactionsRepository
    {
        Task<ICollection<TransactionDto>> GetTransactionsAsync();

        Task<TransactionDto> GetTransactionByIdAsync(string id);

        TransactionDto AddTransaction(TransactionDto transactionDto);
    }
}
