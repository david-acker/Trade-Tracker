using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using TradeTracker.Application.Common.Helpers;
using TradeTracker.Application.Common.Validation.Pagination;
using TradeTracker.Application.Common.Validation.Selection;
using TradeTracker.Application.Features.Transactions.Validators.Querying;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class GetTransactionsQueryValidator : AbstractValidator<GetTransactionsQuery>
    {
        public GetTransactionsQueryValidator()
        {
            When(q => !String.IsNullOrWhiteSpace(q.TransactionType), () =>
            {
                RuleFor(q => q.TransactionType)
                    .SetValidator(new TransactionTypeFilterValidator());
            });

            When(q => !String.IsNullOrWhiteSpace(q.OrderBy), () =>
            {
                RuleFor(q => q.OrderBy)
                    .SetValidator(new TransactionOrderByValidator());
            });

            RuleFor(q => q.PageNumber)
                .SetValidator(new PageNumberValidator());
            
            RuleFor(q => q.PageSize)
                .SetValidator(new PageSizeValidator());

            When(q => !String.IsNullOrWhiteSpace(q.RangeStart), () =>
            {
                RuleFor(q => q.RangeStart)
                    .Must(q => DateTimeRangeHelper.IsValidDateTime(q))
                        .WithMessage("RangeStart must be a valid DateTime.");
            });

            When(q => !String.IsNullOrWhiteSpace(q.RangeEnd), () =>
            {
                RuleFor(q => q.RangeEnd)
                    .Must(q => DateTimeRangeHelper.IsValidDateTime(q))
                        .WithMessage("RangeEnd must be a valid DateTime.");
            });

            When(q => BothRangeValuesProvided(q), () =>
                {
                    RuleFor(q => q)
                        .Must(q => DateTimeRangeHelper.IsStartBeforeEnd(q.RangeStart, q.RangeEnd))
                            .WithMessage("RangeStart must occur before RangeEnd.");
                });

            When(q => !String.IsNullOrWhiteSpace(q.SymbolSelection), () => 
            {
                RuleFor(q => q.SymbolSelection)
                    .SetValidator(new SymbolSelectionValidator());
            });
        }

        private bool BothRangeValuesProvided(GetTransactionsQuery query)
        {
            var rangeValues = new List<string>() { query.RangeStart, query.RangeEnd };

            return rangeValues.All(r => DateTimeRangeHelper.IsValidDateTime(r))
                && rangeValues.All(r => DateTimeRangeHelper.IsNotDefault(r));
        }
    }
}