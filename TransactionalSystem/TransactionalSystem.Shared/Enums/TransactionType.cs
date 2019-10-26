namespace TransactionalSystem.Shared.Enums
{
    public enum TransactionType
    {
        Debit = 1000, 
        Credit = 2000
    }

    public static class TransactionTypeExt
    {
        public static bool IsCredit(this TransactionType type)
        {
            return type == TransactionType.Credit;
        }
    }
}