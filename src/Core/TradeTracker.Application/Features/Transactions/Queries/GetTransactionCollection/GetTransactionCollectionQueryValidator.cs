using System.Linq;
using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactionCollection
{
    public class GetTransactionCollectionQueryValidator : AbstractValidator<GetTransactionCollectionQuery>
    {
        public GetTransactionCollectionQueryValidator()
        {
            RuleFor(t => t.Ids)
                .NotNull()
                .NotEmpty()
                    .WithMessage("The Ids parameter is required.");

            When(t => (t.Ids != null), () =>
            {
                RuleFor(t => t.Ids)
                    .Must(t => t.Count() > 0)
                        .WithMessage("The Ids parameter can not be blank.")
                    .Must(t => t.Count() <= 100)
                        .WithMessage("The number of Ids in a single request may not exceed 100.");
            });
        }
    }
}