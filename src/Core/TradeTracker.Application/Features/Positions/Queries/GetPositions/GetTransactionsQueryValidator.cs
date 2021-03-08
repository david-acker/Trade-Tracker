using System;
using FluentValidation;
using TradeTracker.Application.Features.Transactions.Shared.Validators;

namespace TradeTracker.Application.Features.Positions.Queries.GetPositions
{
    public class GetPositionsQueryValidator : AbstractValidator<GetPositionsQuery>
    {
        public GetPositionsQueryValidator()
        {
            RuleFor(t => t.AccessKey)
                .SetValidator(new AccessKeyValidator());
        }
    }
}