using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Securities.Queries.GetSecurityOverview
{
    public class GetSecurityOverviewQueryHandler : IRequestHandler<GetSecurityOverviewQuery, SecurityOverviewDto>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        
        public GetSecurityOverviewQueryHandler(
            IMapper mapper, 
            ITransactionRepository transactionRepository)
        {
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
            _transactionRepository = transactionRepository
                ?? throw new ArgumentNullException(nameof(transactionRepository));
        }

        public async Task<SecurityOverviewDto> Handle(GetSecurityOverviewQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetSecurityOverviewQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var transactions = await _transactionRepository.GetAllTransactionsForSymbol(request.AccessKey, request.Symbol);

            return new SecurityOverviewDto()
            {
                YearToDate = CreateSummaryGroup(transactions, new DateTime(DateTime.UtcNow.Year, 1, 1)),
                PreviousYear = CreateSummaryGroup(transactions, DateTime.UtcNow.AddYears(-1)),
                CompleteHistory = CreateSummaryGroup(transactions)
            };
        }

        public SummaryGroup CreateSummaryGroup(IEnumerable<Transaction> transactions)
        {
            return CreateSummaryGroup(transactions, DateTime.MinValue);
        }

        public SummaryGroup CreateSummaryGroup(IEnumerable<Transaction> transactions, DateTime calculationCutoff)
        {
            var filteredTransactions = transactions.Where(t => t.DateTime >= calculationCutoff);

            return new SummaryGroup()
            {
                Overall = CalculateForAll(filteredTransactions),
                ByTransactionType = CalculateByTransactionType(filteredTransactions)
            };
        }

        public IEnumerable<SummaryProfile> CalculateByTransactionType(IEnumerable<Transaction> transactions)
        {
            return transactions
                .GroupBy(t => t.TransactionType)
                .Select(t => new SummaryProfile() 
                {
                    TransactionType = t.Key.ToString(),
                    SummaryInformation = new SummaryInformation()
                    {
                        NumberOfTrades = t.Count(),
                        Quantity = new SummaryInformationBlock()
                        {
                            TotalVolume = Math.Round(t.Sum(t => t.Quantity), 6),
                            AveragePerTrade = Math.Round(t.Average(t => t.Quantity), 6),
                        },
                        Notional =new SummaryInformationBlock()
                        {
                            TotalVolume = Math.Round(t.Sum(t => t.Notional), 2),
                            AveragePerTrade = Math.Round(t.Average(t => t.Notional), 2)
                        }
                    }
                });
        }

        public SummaryInformation CalculateForAll(IEnumerable<Transaction> transactions)
        {
            return new SummaryInformation()
            {
                NumberOfTrades = transactions.Count(),
                Quantity = new SummaryInformationBlock()
                {
                    TotalVolume = Math.Round(transactions.Sum(t => t.Quantity), 6),
                    AveragePerTrade = Math.Round(transactions.Average(t => t.Quantity), 6),
                },
                Notional =new SummaryInformationBlock()
                {
                    TotalVolume = Math.Round(transactions.Sum(t => t.Notional), 2),
                    AveragePerTrade = Math.Round(transactions.Average(t => t.Notional), 2)
                }
            };
        }
    }
}
