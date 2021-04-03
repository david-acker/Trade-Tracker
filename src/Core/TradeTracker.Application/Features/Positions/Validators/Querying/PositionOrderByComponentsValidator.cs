using System;
using System.Linq;
using FluentValidation;
using TradeTracker.Application.Common.Enums;
using TradeTracker.Application.Common.Helpers;

namespace TradeTracker.Application.Features.Positions.Querying.Validators
{
    public class PositionOrderByComponentsValidator : AbstractValidator<string>
    {
        readonly string[] PositionOrderByFields = new string[]
        {
            "symbol",
            "quantity"
        };

        public PositionOrderByComponentsValidator()
        {
            RuleFor(s => OrderByParser.extractField(s, ' '))
                .Cascade(CascadeMode.Stop)
                .Must(q => PositionOrderByFields.Contains(q.ToLower()))
                    .WithMessage($"OrderBy requires a valid field name: {String.Join(", ", PositionOrderByFields)}.");
        
            RuleFor(s => OrderByParser.extractSortTypeString(s, ' '))
                .Cascade(CascadeMode.Stop)
                .IsEnumName(typeof(SortType), caseSensitive: false)
                    .WithMessage("A valid SortOrder is required: ascending, descending.")
                .Must(t => OrderByHelper.isSortTypeSpecified(t))
                    .WithMessage("SortOrder cannot be left unspecified.");
        }
    }
}
