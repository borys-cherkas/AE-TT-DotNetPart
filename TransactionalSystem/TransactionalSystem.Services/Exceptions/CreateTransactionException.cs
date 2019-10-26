using System;
using TransactionalSystem.Services.Models.CreateTransaction;

namespace TransactionalSystem.Services.Exceptions
{
    public class CreateTransactionException : Exception
    {
        public CreateTransactionException(CreateTransactionErrors error)
        {
            Error = error;
        }

        public CreateTransactionErrors Error { get; }
    }
}
