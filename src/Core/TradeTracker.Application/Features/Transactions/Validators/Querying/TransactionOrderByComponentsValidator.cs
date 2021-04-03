using System;
using System.Linq;
using FluentValidation;
using TradeTracker.Application.Common.Enums;
using TradeTracker.Application.Common.Helpers;

namespace TradeTracker.Application.Features.Transactions.Validators.Querying
{
    public class TransactionOrderByComponentsValidator : AbstractValidator<string>
    {
        readonly string[] TransactionOrderByFields = new string[]
        {
            "datetime",
            "symbol",
            "quantity",
            "notional"
        };

        public TransactionOrderByComponentsValidator()
        {
            RuleFor(s => OrderByParser.extractField(s, ' '))
                .Cascade(CascadeMode.Stop)
                .Must(q => TransactionOrderByFields.Contains(q.ToLower()))
                    .WithMessage($"OrderBy requires a valid Field: {String.Join(", ", TransactionOrderByFields)}.");
        
            RuleFor(s => OrderByParser.extractSortTypeString(s, ' '))
                .Cascade(CascadeMode.Stop)
                .IsEnumName(typeof(SortType), caseSensitive: false)
                    .WithMessage("A valid SortOrder is required: ascending, descending.")
                .Must(t => OrderByHelper.isSortTypeSpecified(t))
                    .WithMessage("SortOrder cannot be left unspecified.");
        }
    }
}
