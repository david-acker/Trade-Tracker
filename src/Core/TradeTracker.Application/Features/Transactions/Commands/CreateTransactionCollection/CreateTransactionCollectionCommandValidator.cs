using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Commands.CreateTransactionCollection
{
    public class CreateTransactionCollectionCommandValidator : AbstractValidator<CreateTransactionCollectionCommand>
    {
        public CreateTransactionCollectionCommandValidator()
        {
            RuleForEach(t => t.Transactions).SetValidator(new CreateTransactionCommandBaseValidator());
        }
    }
}
