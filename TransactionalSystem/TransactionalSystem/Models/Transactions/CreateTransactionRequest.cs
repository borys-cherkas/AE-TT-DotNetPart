using System.ComponentModel.DataAnnotations;
using TransactionalSystem.Attributes;

namespace TransactionalSystem.Models.Transactions
{
    public class CreateTransactionRequest
    {
        [Required]
        [CreditDebit]
        public string Type { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }
    }
}
