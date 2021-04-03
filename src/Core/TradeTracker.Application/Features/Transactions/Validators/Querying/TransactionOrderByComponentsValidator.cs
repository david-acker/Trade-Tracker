using FluentValidation;
using TradeTracker.Application.Common.Enums;
using TradeTracker.Application.Common.Helpers;

namespace TradeTracker.Application.Features.Transactions.Validators.Querying
{
    public class TransactionOrderByComponentsValidator : AbstractValidator<string>
    {
        public TransactionOrderByComponentsValidator()
        {
            RuleFor(s => OrderByParser.ExtractField(s, ' '))
                .Cascade(CascadeMode.Stop)
                .Must(q => EnumHelper.ToList<TransactionOrderByField>(1).Contains(q.ToLower()))
                    .WithMessage($"OrderBy requires a valid Field: {EnumHelper.Display<TransactionOrderByField>(1)}.");
        
            RuleFor(s => OrderByParser.ExtractSortTypeString(s, ' '))
                .Cascade(CascadeMode.Stop)
                .IsEnumName(typeof(SortType), caseSensitive: false)
                    .WithMessage("A valid SortOrder is required: ascending, descending.")
                .Must(t => EnumHelper.IsNotDefault<SortType>(t))
                    .WithMessage("SortOrder cannot be left unspecified.");
        }
    }
}
