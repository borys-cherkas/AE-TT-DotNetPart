namespace TransactionalSystem.Models.Transactions
{
    public class GetTransactionResponse : ResponseBase
    {
        public GetTransactionResponse(TransactionItem transaction)
        {
            Transaction = transaction;
        }

        public TransactionItem Transaction { get; set; }
    }
}
