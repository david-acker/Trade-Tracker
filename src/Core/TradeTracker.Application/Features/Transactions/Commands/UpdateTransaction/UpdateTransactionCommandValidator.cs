using FluentValidation;
using TradeTracker.Application.Features.Transactions.Validators.Transactions;

namespace TradeTracker.Application.Features.Transactions.Commands.UpdateTransaction
{
    public class UpdateTransactionCommandValidator : AbstractValidator<UpdateTransactionCommand>
    {
        public UpdateTransactionCommandValidator()
        {
            RuleFor(t => t.Id)
                .SetValidator(new TransactionIdValidator());

            RuleFor(t => t.DateTime)
                .SetValidator(new DateTimeValidator());
            
            RuleFor(t => t.Symbol)
                .SetValidator(new SymbolValidator());

            RuleFor(t => t.Type)
                .SetValidator(new TransactionTypeValidator());

            RuleFor(t => t.Quantity)
                .SetValidator(new QuantityValidator());

            RuleFor(t => t.Notional)
                .SetValidator(new NotionalValidator());

            RuleFor(t => t.TradePrice)
                .SetValidator(new TradePriceValidator());
        }
    }
}
