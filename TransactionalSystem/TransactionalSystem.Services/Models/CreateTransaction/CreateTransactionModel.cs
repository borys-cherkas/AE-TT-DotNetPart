using TransactionalSystem.Shared.Enums;

namespace TransactionalSystem.Services.Models.CreateTransaction
{
    public class CreateTransactionModel
    {
        public TransactionType Type { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }
    }
}
