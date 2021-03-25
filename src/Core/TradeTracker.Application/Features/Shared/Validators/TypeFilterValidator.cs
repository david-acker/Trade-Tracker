using System;
using System.Linq;
using FluentValidation;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Application.Features.Transactions.Shared.Validators
{
    public class TransactionTypeForFilteringValidator : AbstractValidator<string>
    {
        public TransactionTypeForFilteringValidator()
        {
            RuleFor(t => t)
                .Must(t => IsValidTransactionTypeForFiltering(t))
                    .WithMessage("Cannot filter with an invalid TransactionType.");
        }
        
        private bool IsValidTransactionTypeForFiltering(string input)
        {   
            var validTypes = new string[] { "buy", "sell" };

            if (!String.IsNullOrWhiteSpace(input))
            {
                if (!validTypes.Contains(input.Trim()))
                {
                    return false;
                }
            }

            return true;
        }
    }
}