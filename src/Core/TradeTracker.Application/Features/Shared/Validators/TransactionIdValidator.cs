using System;
using FluentValidation;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Application.Features.Transactions.Shared.Validators
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
