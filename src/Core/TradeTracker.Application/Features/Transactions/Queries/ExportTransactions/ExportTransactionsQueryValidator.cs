using FluentValidation;

namespace TradeTracker.Application.Features.Transactions.Queries.ExportTransactions
{
    public class ExportTransactionsQueryValidator : AbstractValidator<ExportTransactionsQuery>
    {
        public ExportTransactionsQueryValidator()
        {
        }
    }
}