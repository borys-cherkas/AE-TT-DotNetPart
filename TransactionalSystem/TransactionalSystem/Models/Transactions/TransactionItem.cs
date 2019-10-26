using System;

namespace TransactionalSystem.Models.Transactions
{
    public class TransactionItem
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public decimal Amount { get; set; }

        public DateTime EffectiveDate { get; set; }
    }
}
