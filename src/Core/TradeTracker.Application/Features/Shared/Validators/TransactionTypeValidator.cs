using System;
using FluentValidation;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Application.Features.Transactions.Shared.Validators
{
    public class TransactionTypeValidator : AbstractValidator<string>
    {
        public TransactionTypeValidator()
        {
            RuleFor(t => t)
                .NotNull()
                .NotEmpty()
                    .WithMessage("A TransactionType is required.")
                .IsEnumName(typeof(TransactionType), caseSensitive: false)
                    .WithMessage("A valid TransactionType is required.")
                .Must(t => IsTransactionTypeSpecified(t))
                    .WithMessage("The {TransactionType} cannot be unspecified.");
        }
        
        private bool IsTransactionTypeSpecified(string input)
        {   
            var isValid = false;

            TransactionType transactionType;
            if (Enum.TryParse(input, true, out transactionType))
            {
                if (transactionType != TransactionType.NotSpecified)
                {
                    isValid = true;
                }
            }

            return isValid;
        }
    }
}
