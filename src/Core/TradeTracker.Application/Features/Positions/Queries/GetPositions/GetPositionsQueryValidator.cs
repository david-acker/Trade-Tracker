using System;
using System.Collections.Generic;
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
        }
    }
}