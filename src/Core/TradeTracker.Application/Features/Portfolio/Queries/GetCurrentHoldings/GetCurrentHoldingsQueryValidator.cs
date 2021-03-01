using FluentValidation;

namespace TradeTracker.Application.Features.Portfolio.Queries.GetCurrentHoldings
{
    public class GetCurrentHoldingsQueryValidator : AbstractValidator<GetCurrentHoldingsQuery>
    {
        public GetCurrentHoldingsQueryValidator()
        {
            RuleFor(q => q.AccessKey).SetValidator(new AccessKeyValidator());
        }
    }
}