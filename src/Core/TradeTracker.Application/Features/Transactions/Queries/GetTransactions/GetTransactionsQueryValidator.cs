using System;
using FluentValidation;
using TradeTracker.Application.Common.Validation.Pagination;
using TradeTracker.Application.Common.Validation.Selection;
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
                .Must(q => isValidDateTime(q))
                    .WithMessage("RangeStart must be a valid DateTime.");
            
            RuleFor(q => q.RangeEnd)
                .Must(q => isValidDateTime(q))
                    .WithMessage("RangeEnd must be a valid DateTime.");

            When(q => bothValidRangeValues(q.RangeStart, q.RangeEnd) 
                && !isDefaultRangeValues(q.RangeStart, q.RangeEnd), () =>
                {
                    RuleFor(q => q)
                        .Must(q => startIsBeforeEnd(q.RangeStart, q.RangeEnd))
                            .WithMessage("RangeStart must occur before RangeEnd.");
                });

            When(q => !String.IsNullOrWhiteSpace(q.SymbolSelection), () => 
            {
                RuleFor(q => q.SymbolSelection)
                    .SetValidator(new SymbolSelectionValidator());
            });
        }

        private bool isDefaultRangeValues(string rangeStart, string rangeEnd)
        {
            var start = DateTime.Parse(rangeStart);
            var end = DateTime.Parse(rangeEnd);

            bool isStartDefault = start.Date.Equals(DateTime.MinValue.Date);
            bool isEndDefault = end.Date.Equals(DateTime.MaxValue.Date);

            bool bothDefault = isStartDefault && isEndDefault;

            return bothDefault;
        }

        private bool startIsBeforeEnd(string rangeStart, string rangeEnd)
        {
            var start = DateTime.Parse(rangeStart);
            var end = DateTime.Parse(rangeEnd);

            return (start < end);
        }

        private bool bothValidRangeValues(string rangeStart, string rangeEnd)
        {
            bool isStartValid = isValidDateTime(rangeStart);
            bool isEndValid = isValidDateTime(rangeEnd);

            bool bothValid = isStartValid && isEndValid;

            return bothValid;
        }

        private bool isValidDateTime(string input)
        {
            bool isValid = DateTime.TryParse(input, out _);

            return isValid;
        }
    }
}