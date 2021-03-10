using System;
using System.Collections.Generic;
using System.Linq;
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

            var OrderByFields = new List<string>()
            {
                "Symbol",
                "Quantity"
            };

            RuleFor(q => q.OrderBy)
                .Must(q => OrderByFields.Contains(q))
                    .WithMessage($"The OrderBy clause requires one of the valid fields: {String.Join(", ", OrderByFields)}.");
            
            var ValidExposureTypes = new List<string>()
            {
                "Long",
                "Short"
            };

            When(q => !String.IsNullOrWhiteSpace(q.Exposure), () =>
            {
                RuleFor(q => q.Exposure)
                    .Must(q => ValidExposureTypes.Contains(q))
                        .WithMessage($"The Exposure filter requires one of the valid types: {String.Join(", ", ValidExposureTypes)}.");
            });

            When(q => (
                (q.Including.Count() > 0) ||
                (q.Excluding.Count() > 0)), () => 
            {
                RuleFor(q => q)
                    .Must(q => HasEitherIncludingOrExcluding(q.Including, q.Excluding))
                        .WithMessage("Including and Excluding parameters cannot be used together");
            });

        }

        private bool HasEitherIncludingOrExcluding(List<string> including, List<string> excluding)
        {
            var isValid = false;
            
            if (including.Count() == 0 || excluding.Count() == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}