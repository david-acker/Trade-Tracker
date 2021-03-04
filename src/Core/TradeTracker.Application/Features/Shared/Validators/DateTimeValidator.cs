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
                    .WithMessage("The DateTime may not be blank.")
                .LessThanOrEqualTo(DateTime.Now)
                    .WithMessage("The DateTime must have already occurred.");
        }
    }
}
