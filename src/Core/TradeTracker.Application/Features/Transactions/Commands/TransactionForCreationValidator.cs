using FluentValidation;
using TradeTracker.Application.Features.Transactions.Shared.Validators;

namespace TradeTracker.Application.Features.Transactions.Commands
{
    public class TransactionForCreationValidator : AbstractValidator<TransactionForCreationDto>
    {
        public TransactionForCreationValidator()
        {
            RuleFor(t => t.DateTime)
                .SetValidator(new DateTimeValidator());
            
            RuleFor(t => t.Symbol)
                .SetValidator(new SymbolValidator());

            RuleFor(t => t.TransactionType)
                .SetValidator(new TransactionTypeValidator());

            RuleFor(t => t.Quantity)
                .SetValidator(new QuantityValidator());

            RuleFor(t => t.Notional)
                .SetValidator(new NotionalValidator());

            When(t => (t.TradePrice != null), () =>
            {
                RuleFor(t => t.TradePrice)
                    .SetValidator(new TradePriceValidator());
            });

            RuleFor(t => t.Tags)
                .SetValidator(new TagsValidator());
        }
    }
}