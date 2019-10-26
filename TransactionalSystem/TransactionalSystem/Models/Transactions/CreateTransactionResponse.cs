using System;

namespace TransactionalSystem.Models.Transactions
{
    public class CreateTransactionResponse : ResponseBase
    {
        public CreateTransactionResponse(TransactionItem transaction)
        {
            Id = transaction.Id;
            Type = transaction.Type;
            Amount = transaction.Amount;
            EffectiveDate = transaction.EffectiveDate;
        }

        public string Id { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
