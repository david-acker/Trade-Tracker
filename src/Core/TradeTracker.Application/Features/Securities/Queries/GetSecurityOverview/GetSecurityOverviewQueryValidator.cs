using FluentValidation;
using TradeTracker.Application.Features.Transactions.Shared.Validators;

namespace TradeTracker.Application.Features.Securities.Queries.GetSecurityOverview
{
    public class GetSecurityOverviewQueryValidator : AbstractValidator<GetSecurityOverviewQuery>
    {
        public GetSecurityOverviewQueryValidator()
        {
            RuleFor(s => s.Symbol)
                .SetValidator(new SymbolValidator());
        }
    }
}
