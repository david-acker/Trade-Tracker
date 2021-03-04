using System;
using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Shared.Validators
{
    public class TradePriceValidator : AbstractValidator<Decimal?>
    {
        public TradePriceValidator()
        {
            RuleFor(t => t)
                .GreaterThan(0)
                    .WithMessage("If provided, the TradePrice must be greater than zero.");
        }
    }
}
