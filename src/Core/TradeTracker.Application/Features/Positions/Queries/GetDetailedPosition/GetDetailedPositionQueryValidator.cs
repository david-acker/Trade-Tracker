using FluentValidation;
using TradeTracker.Application.Features.Transactions.Shared.Validators;
using TradeTracker.Application.Features.Transactions.Validators.Transactions;

namespace TradeTracker.Application.Features.Positions.Queries.GetPosition
{
    public class GetDetailedPositionQueryValidator : AbstractValidator<GetDetailedPositionQuery>
    {
        public GetDetailedPositionQueryValidator()
        {

            RuleFor(t => t.Symbol)
                .SetValidator(new SymbolValidator());
        }
    }
}