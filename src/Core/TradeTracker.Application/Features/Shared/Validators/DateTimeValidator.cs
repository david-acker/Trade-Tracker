using System;
using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Shared.Validators
{
    public class DateTimeValidator : AbstractValidator<DateTime>
    {
        public DateTimeValidator()
        {
            RuleFor(t => t)
                .NotNull()
                .NotEmpty()
                    .WithMessage("DateTime may not be blank.")
                .LessThanOrEqualTo(DateTime.Now)
                    .WithMessage("DateTime must have already occurred.");
        }
    }
}
