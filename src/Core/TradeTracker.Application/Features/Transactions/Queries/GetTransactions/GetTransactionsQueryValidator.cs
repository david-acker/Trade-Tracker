using System;
using System.Collections.Generic;
using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class GetTransactionsQueryValidator : AbstractValidator<GetTransactionsQuery>
    {
        public GetTransactionsQueryValidator()
        {
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
        }
    }
}