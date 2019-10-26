using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionalSystem.Services.Models;
using TransactionalSystem.Services.Models.CreateTransaction;

namespace TransactionalSystem.Services
{
    public interface ITransactionsService
    {
        Task<ICollection<TransactionDetailsModel>> GetAllTransactionsAsync();

        Task<TransactionDetailsModel> GetTransactionByIdAsync(string id);

        Task<TransactionDetailsModel> CreateTransactionAsync(CreateTransactionModel transaction);
    }
}
