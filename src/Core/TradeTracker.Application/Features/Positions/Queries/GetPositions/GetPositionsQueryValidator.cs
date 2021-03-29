using System;
using FluentValidation;
using TradeTracker.Application.Features.Positions.Validators.Querying;
using TradeTracker.Application.Features.Transactions.Shared.Validators;
using TradeTracker.Application.Validators.Pagination;
using TradeTracker.Application.Validators.Selection;

namespace TradeTracker.Application.Features.Positions.Queries.GetPositions
{
    public class GetPositionsQueryValidator : AbstractValidator<GetPositionsQuery>
    {
        public GetPositionsQueryValidator()
        {
            RuleFor(t => t.AccessKey)
                .SetValidator(new AccessKeyValidator());

            When(q => !String.IsNullOrWhiteSpace(q.Exposure), () =>
            {
                RuleFor(q => q.Exposure)
                    .SetValidator(new ExposureTypeFilterValidator());
            });

            RuleFor(q => q.Order)
                .SetValidator(new PositionOrderValidator());

            RuleFor(q => q.PageNumber)
                .SetValidator(new PageNumberValidator());
            
            RuleFor(q => q.PageSize)
                .SetValidator(new PageSizeValidator());

            When(q => !String.IsNullOrWhiteSpace(q.Selection), () => 
            {
                RuleFor(q => q.Selection)
                    .SetValidator(new SelectionValidator());
            });

        }
    }
}