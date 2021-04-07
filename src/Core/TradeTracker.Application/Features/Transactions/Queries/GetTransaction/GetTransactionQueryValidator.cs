using FluentValidation;
using TradeTracker.Application.Features.Transactions.Validators.Transactions;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransaction
{
    public class GetTransactionQueryValidator : AbstractValidator<GetTransactionQuery>
    {
        public GetTransactionQueryValidator()
        {
            RuleFor(t => t.Id)
                .SetValidator(new TransactionIdValidator());
        }
    }
}