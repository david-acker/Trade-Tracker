using FluentValidation;
using TradeTracker.Application.Common.Enums;
using TradeTracker.Application.Common.Helpers;

namespace TradeTracker.Application.Features.Positions.Querying.Validators
{
    public class PositionOrderByComponentsValidator : AbstractValidator<string>
    {
        public PositionOrderByComponentsValidator()
        {
            RuleFor(s => OrderByParser.ExtractField(s, ' '))
                .Cascade(CascadeMode.Stop)
                .Must(q => EnumHelper.ToList<PositionOrderByField>(1).Contains(q.ToLower()))
                    .WithMessage($"OrderBy requires a valid field: {EnumHelper.Display<PositionOrderByField>(1)}.");
        
            RuleFor(s => OrderByParser.ExtractSortTypeString(s, ' '))
                .Cascade(CascadeMode.Stop)
                .IsEnumName(typeof(SortType), caseSensitive: false)
                    .WithMessage("A valid SortOrder is required: ascending, descending.")
                .Must(t => EnumHelper.IsNotDefault<SortType>(t))
                    .WithMessage("SortOrder cannot be left unspecified.");
        }
    }
}
