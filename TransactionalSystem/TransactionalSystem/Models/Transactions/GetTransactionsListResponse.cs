using System.Collections.Generic;
using System.Linq;

namespace TransactionalSystem.Models.Transactions
{
    public class GetTransactionsListResponse : ResponseBase
    {
        public GetTransactionsListResponse(ICollection<TransactionItem> transactions)
        {
            Transactions = transactions.ToList();
        }

        public ICollection<TransactionItem> Transactions { get; set; }
    }
}
