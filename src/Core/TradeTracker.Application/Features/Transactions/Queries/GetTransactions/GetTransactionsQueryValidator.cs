using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using TradeTracker.Application.Common.Validation.Pagination;
using TradeTracker.Application.Common.Validation.Selection;
using TradeTracker.Application.Features.Transactions.Helpers;
using TradeTracker.Application.Features.Transactions.Validators.Querying;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class GetTransactionsQueryValidator : AbstractValidator<GetTransactionsQuery>
    {
        public GetTransactionsQueryValidator()
        {
            RuleFor(q => q.TransactionType)
                .SetValidator(new TransactionTypeFilterValidator());

            When(q => !String.IsNullOrWhiteSpace(q.OrderBy), () =>
            {
                RuleFor(q => q.OrderBy)
                    .SetValidator(new TransactionOrderByValidator());
            });

            RuleFor(q => q.PageNumber)
                .SetValidator(new PageNumberValidator());
            
            RuleFor(q => q.PageSize)
                .SetValidator(new PageSizeValidator());

            RuleFor(q => q.RangeStart)
                .Must(q => DateTimeRangeHelper.IsValidDateTime(q))
                    .WithMessage("RangeStart must be a valid DateTime.");
            
            RuleFor(q => q.RangeEnd)
                .Must(q => DateTimeRangeHelper.IsValidDateTime(q))
                    .WithMessage("RangeEnd must be a valid DateTime.");

            When(q => 
            {
                var rangeValues = new List<string>() { q.RangeStart, q.RangeEnd };

                return rangeValues.All(r => DateTimeRangeHelper.IsValidDateTime(r))
                    && rangeValues.All(r => DateTimeRangeHelper.IsNotDefault(r));
            }, () =>
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
    }
}