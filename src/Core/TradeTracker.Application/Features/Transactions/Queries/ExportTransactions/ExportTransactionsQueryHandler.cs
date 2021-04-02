using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Interfaces;
using TradeTracker.Application.Interfaces.Infrastructure;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Requests;
using TradeTracker.Application.ResourceParameters.Unpaged;

namespace TradeTracker.Application.Features.Transactions.Queries.ExportTransactions
{
    public class ExportTransactionsQueryHandler : 
        ValidatableRequestHandler<ExportTransactionsQuery>,
        IRequestHandler<ExportTransactionsQuery, TransactionsExportFileVm>
    {
        private readonly ICsvExporter _csvExporter;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;

        public ExportTransactionsQueryHandler(
            ICsvExporter csvExporter,
            IMapper mapper, 
            IAuthenticatedTransactionRepository authenticatedTransactionRepository)
        {
            _csvExporter = csvExporter;
            _mapper = mapper;
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
        }

        public async Task<TransactionsExportFileVm> Handle(ExportTransactionsQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var transactions = (await _authenticatedTransactionRepository
                .GetUnpagedResponseAsync(new UnpagedTransactionsResourceParameters()))
                .OrderBy(x => x.DateTime);

            var transactionsForReturn= _mapper.Map<List<TransactionsForExportDto>>(transactions);

            var fileData = _csvExporter.ExportTransactionsToCsv(transactionsForReturn);

            var transactionExportFileDto = new TransactionsExportFileVm() 
            { 
                ContentType = "text/csv",
                Data = fileData, 
                TransactionsExportFileName = $"{Guid.NewGuid()}.csv" 
            };

            return transactionExportFileDto;
        }
    }
}
