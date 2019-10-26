using System.ComponentModel.DataAnnotations;
using TransactionalSystem.Shared.Enums;

namespace TransactionalSystem.Attributes
{
    public class CreditDebitAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {

            if (value.Equals(TransactionType.Credit.ToString().ToLower())
                || value.Equals(TransactionType.Debit.ToString().ToLower()))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Type is invalid.");
        }
    }
}
