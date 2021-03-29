using FluentValidation;
using TradeTracker.Application.Features.Transactions.Shared.Validators;
using TradeTracker.Application.Features.Transactions.Validators.Transactions;

namespace TradeTracker.Application.Features.Positions.Queries.GetPosition
{
    public class GetPositionQueryValidator : AbstractValidator<GetPositionQuery>
    {
        public GetPositionQueryValidator()
        {
            RuleFor(t => t.AccessKey)
                .SetValidator(new AccessKeyValidator());

            RuleFor(t => t.Symbol)
                .SetValidator(new SymbolValidator());
        }
    }
}