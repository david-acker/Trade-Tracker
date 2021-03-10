using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using TradeTracker.Application.Features.Transactions.Shared.Validators;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class GetTransactionsQueryValidator : AbstractValidator<GetTransactionsQuery>
    {
        public GetTransactionsQueryValidator()
        {
            RuleFor(q => q.AccessKey)
                .SetValidator(new AccessKeyValidator());

            var OrderByFields = new List<string>()
            {
                "DateTime",
                "Symbol",
                "Quantity",
                "Notional"
            };

            RuleFor(q => q.OrderBy)
                .Must(q => OrderByFields.Contains(q))
                    .WithMessage($"The OrderBy clause requires one of the valid fields: {String.Join(", ", OrderByFields)}.");
            
            When(q => (
                (q.RangeStart != DateTime.MinValue && q.RangeEnd != DateTime.MaxValue) &&
                (q.RangeEnd != DateTime.MinValue)), () =>
                    {
                        RuleFor(q => new { q.RangeStart, q.RangeEnd })
                            .Must(q => (q.RangeStart < q.RangeEnd))
                                .WithMessage("The RangeEnd must be after the RangeStart.");
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