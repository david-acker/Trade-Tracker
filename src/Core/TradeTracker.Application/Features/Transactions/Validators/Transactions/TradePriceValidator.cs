using System;
using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Validators.Transactions
{
    public class TradePriceValidator : AbstractValidator<Decimal>
    {
        public TradePriceValidator()
        {
            RuleFor(t => t)
                .GreaterThan(0)
                    .WithMessage("TradePrice must be greater than zero.");
        }
    }
}
