using System;
using System.Linq;
using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Validators.Querying
{
    public class TransactionTypeFilterValidator : AbstractValidator<string>
    {
        public TransactionTypeFilterValidator()
        {
            RuleFor(t => t)
                .Must(t => IsValidTransactionTypeForFiltering(t))
                    .WithMessage("Cannot filter with an invalid TransactionType.");
        }
        
        private bool IsValidTransactionTypeForFiltering(string input)
        {   
            var validTransactionTypes = new string[]
            { 
                "buy", 
                "sell" 
            };

            var cleanedInput = input
                .Trim()
                .ToLower();
            
            return validTransactionTypes.Contains(cleanedInput);
        }
    }
}