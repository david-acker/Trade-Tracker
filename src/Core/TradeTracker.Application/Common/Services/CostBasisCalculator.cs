using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Enums;
using TradeTracker.Application.Common.Interfaces;
using TradeTracker.Application.Common.Interfaces.Persistence.Positions;
using TradeTracker.Application.Common.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Common.Models.Resources.Parameters.Transactions;
using TradeTracker.Application.Common.Models.Resources.Requests;
using TradeTracker.Application.Features.Positions;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Application.Common.Services
{
    class CostBasisCalculator : ICostBasisCalculator
    {
        private readonly IAuthenticatedPositionRepository _authenticatedPositionRepository;
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;

        public CostBasisCalculator(
            IAuthenticatedPositionRepository authenticatedPositionRepository,
            IAuthenticatedTransactionRepository authenticatedTransactionRepository)
        {
            _authenticatedPositionRepository = authenticatedPositionRepository;
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
        }

        public async Task<decimal> CalculateAverageCostBasis(
            string symbol)
        {
            var sourceRelations = await CreateSourceRelations(symbol);

            decimal totalNotional = sourceRelations
                .Sum(p => p.Quantity * p.TradePrice);

            decimal totalQuantity = sourceRelations
                .Sum(p => p.Quantity);

            return Math.Round(totalNotional / totalQuantity, 2);
        }

        public async Task<IEnumerable<SourceRelation>> CreateSourceRelations(
            string symbol)
        {
            var position = await _authenticatedPositionRepository
                .GetBySymbolAsync(symbol);

            var parametersForSymbol = new UnpagedTransactionsResourceParameters()
            {
                SymbolSelection = new SymbolSelection(
                    new List<string>() { symbol },
                    SelectionType.Include),
                TransactionType = TransactionType.Buy
            };

            IEnumerable<Transaction> transactionsForSymbol =
                await _authenticatedTransactionRepository
                    .GetUnpagedResponseAsync(parametersForSymbol);

            var sourceRelations = new List<SourceRelation>();
            var remainingQuantity = position.Quantity;

            foreach (var transaction in transactionsForSymbol)
            {
                var quantity = transaction.Quantity;
                var tradePrice = transaction.TradePrice;

                if (remainingQuantity > quantity)
                {
                    sourceRelations.Add(
                        new SourceRelation(transaction, quantity));
                    remainingQuantity -= quantity;
                }
                else
                {
                    sourceRelations.Add(
                        new SourceRelation(transaction, remainingQuantity));
                    break;
                }
            }

            return sourceRelations;
        }
    }
}
