using System.Linq;
using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactionCollection
{
    public class GetTransactionCollectionQueryValidator : AbstractValidator<GetTransactionCollectionQuery>
    {
        public GetTransactionCollectionQueryValidator()
        {
            RuleFor(t => t.TransactionIds)
                .NotNull()
                .NotEmpty()
                    .WithMessage("The TransactionIds parameter is required.");

            When(t => (t.TransactionIds != null), () =>
            {
                RuleFor(t => t.TransactionIds)
                    .Must(t => t.Count() > 0)
                        .WithMessage("The TransactionIds parameter can not be blank.")
                    .Must(t => t.Count() <= 100)
                        .WithMessage("The number of TransactionIds in a single request may not exceed 100.");
        
            });
        }
    }
}