using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Validators.Transactions
{
    public class NotionalValidator : AbstractValidator<decimal>
    {
        public NotionalValidator()
        {
            RuleFor(t => t)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Notional must not be blank.")
                .GreaterThan(0)
                    .WithMessage("Notional must be greater than zero.");
        }
    }
}
