using System;
using System.Collections.Generic;
using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactionsList
{
    public class GetTransactionsListQueryValidator : AbstractValidator<GetTransactionsListQuery>
    {
        public GetTransactionsListQueryValidator()
        {
            var OrderByFields = new List<string>()
            {
                "DateTime",
                "Symbol",
                "Quantity",
                "Notional"
            };

            RuleFor(q => q.AccessKey)
                .SetValidator(new AccessKeyValidator());

            RuleFor(q => q.OrderBy)
                .Must(q => OrderByFields.Contains(q))
                    .WithMessage($"The OrderBy clause requires one of the valid fields: {String.Join(", ", OrderByFields)}.");
            
            When(q => (
                (q.StartRange != DateTime.MinValue && q.EndRange != DateTime.MaxValue) &&
                (q.EndRange != DateTime.MinValue)), () =>
                    {
                        RuleFor(q => new { q.StartRange, q.EndRange })
                            .Must(q => (q.StartRange < q.EndRange))
                                .WithMessage("The EndRange must be after the StartRange.");
                    });
        }
    }
}