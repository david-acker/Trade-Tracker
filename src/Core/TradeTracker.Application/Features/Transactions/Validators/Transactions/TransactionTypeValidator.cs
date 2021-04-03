using System;
using FluentValidation;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Application.Features.Transactions.Validators.Transactions
{
    public class TransactionTypeValidator : AbstractValidator<string>
    {
        public TransactionTypeValidator()
        {
            RuleFor(t => t)
                .NotNull()
                .NotEmpty()
                    .WithMessage("TransactionType is required.")
                .IsEnumName(typeof(TransactionType), caseSensitive: false)
                    .WithMessage("A valid TransactionType is required.")
                .Must(t => IsTransactionTypeSpecified(t))
                    .WithMessage("TransactionType cannot be left unspecified.");
        }
        
        private bool IsTransactionTypeSpecified(string input)
        {   
            var isSpecified = false;

            if (Enum.TryParse(input, true, out TransactionType transactionType))
            {
                if (transactionType != TransactionType.NotSpecified)
                {
                    isSpecified = true;
                }
            }

            return isSpecified;
        }
    }
}
