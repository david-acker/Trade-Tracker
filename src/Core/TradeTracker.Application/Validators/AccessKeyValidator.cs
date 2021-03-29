using System;
using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Shared.Validators
{
    public class AccessKeyValidator : AbstractValidator<Guid>
    {
        public AccessKeyValidator()
        {
            RuleFor(t => t)
                .NotNull()
                .NotEmpty()
                    .WithMessage("An authentication issue has occurred. Please refresh and try again.");
        }
    }
}
