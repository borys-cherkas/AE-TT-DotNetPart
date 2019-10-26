using System;
using TransactionalSystem.Shared.Enums;

namespace TransactionalSystem.Data.Entities
{
    internal class TransactionEntity
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public TransactionType Type { get; set; }

        public DateTime Occured { get; set; }
    }
}
