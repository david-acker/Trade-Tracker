using System.Linq;
using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactionCollection
{
    public class GetTransactionCollectionValidator : AbstractValidator<GetTransactionCollectionQuery>
    {
        public GetTransactionCollectionValidator()
        {
            RuleFor(t => t.TransactionIds)
                .Must(t => t.Count() > 0)
                    .WithMessage("The TransactionIds parameter may not be blank")
                .Must(t => t.Count() <= 100)
                    .WithMessage("The number of TransactionIds in a single request may not exceed 100.");
        }
    }
}