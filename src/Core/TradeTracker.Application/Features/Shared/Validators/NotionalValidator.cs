using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Shared.Validators
{
    public class NotionalValidator : AbstractValidator<decimal>
    {
        public NotionalValidator()
        {
            RuleFor(t => t)
                .NotNull()
                .NotEmpty()
                    .WithMessage("The Notional must not be blank.")
                .GreaterThan(0)
                    .WithMessage("The Notional must be greater than zero.");
        }
    }
}
