using System;
using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Validators.Transactions
{
    public class TransactionIdValidator : AbstractValidator<Guid>
    {
        public TransactionIdValidator()
        {
            RuleFor(t => t)
                .NotNull()
                .NotEmpty()
                    .WithMessage("A valid TransactionId is required.");
        }
    }
}
