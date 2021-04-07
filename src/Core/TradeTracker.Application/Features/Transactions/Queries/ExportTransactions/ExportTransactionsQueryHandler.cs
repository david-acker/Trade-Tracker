using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Behaviors;
using TradeTracker.Application.Common.Interfaces.Infrastructure;
using TradeTracker.Application.Common.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Common.Models.Resources.Parameters.Transactions;

namespace TradeTracker.Application.Features.Transactions.Queries.ExportTransactions
{
    public class ExportTransactionsQueryHandler : 
        ValidatableRequestBehavior<ExportTransactionsQuery>,
        IRequestHandler<ExportTransactionsQuery, TransactionsForExportFileVm>
    {
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;
        private readonly ICsvExporter _csvExporter;
        private readonly IMapper _mapper;

        public ExportTransactionsQueryHandler(
            IAuthenticatedTransactionRepository authenticatedTransactionRepository,
            ICsvExporter csvExporter,
            IMapper mapper)
        {
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
            _csvExporter = csvExporter;
            _mapper = mapper;
        }

        public async Task<TransactionsForExportFileVm> Handle(ExportTransactionsQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var transactions = await _authenticatedTransactionRepository
                .GetUnpagedResponseAsync(new UnpagedTransactionsResourceParameters());

            var transactionsForReturn= _mapper.Map<List<TransactionForExport>>(transactions);

            var fileData = _csvExporter.ExportTransactionsToCsv(transactionsForReturn);

            var transactionExportFileDto = new TransactionsForExportFileVm() 
            { 
                ContentType = "text/csv",
                Data = fileData, 
                TransactionsExportFileName = $"{Guid.NewGuid()}.csv" 
            };

            return transactionExportFileDto;
        }
    }
}
