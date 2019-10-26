using System;
using TransactionalSystem.Shared.Enums;

namespace TransactionalSystem.Data.Dtos
{
    public class TransactionDto
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public TransactionType Type { get; set; }

        public DateTime Occured { get; set; }
    }
}
