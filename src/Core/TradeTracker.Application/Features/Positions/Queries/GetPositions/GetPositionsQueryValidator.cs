using System;
using FluentValidation;
using TradeTracker.Application.Common.Validation.Pagination;
using TradeTracker.Application.Common.Validation.Selection;
using TradeTracker.Application.Features.Positions.Querying.Validators;

namespace TradeTracker.Application.Features.Positions.Queries.GetPositions
{
    public class GetPositionsQueryValidator : AbstractValidator<GetPositionsQuery>
    {
        public GetPositionsQueryValidator()
        {
            When(q => !String.IsNullOrWhiteSpace(q.ExposureType), () =>
            {
                RuleFor(q => q.ExposureType)
                    .SetValidator(new ExposureTypeFilterValidator());
            });

            When(q => !String.IsNullOrWhiteSpace(q.OrderBy), () =>
            {
                RuleFor(q => q.OrderBy)
                    .SetValidator(new PositionOrderByValidator());
            });

            RuleFor(q => q.PageNumber)
                .SetValidator(new PageNumberValidator());
            
            RuleFor(q => q.PageSize)
                .SetValidator(new PageSizeValidator());

            When(q => !String.IsNullOrWhiteSpace(q.SymbolSelection), () => 
            {
                RuleFor(q => q.SymbolSelection)
                    .SetValidator(new SymbolSelectionValidator());
            });
        }
    }
}