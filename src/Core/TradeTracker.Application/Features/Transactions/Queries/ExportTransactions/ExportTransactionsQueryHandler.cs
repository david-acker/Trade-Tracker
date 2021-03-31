using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Interfaces.Infrastructure;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Requests;

namespace TradeTracker.Application.Features.Transactions.Queries.ExportTransactions
{
    public class ExportTransactionsQueryHandler : 
        ValidatableRequestHandler<ExportTransactionsQuery>,
        IRequestHandler<ExportTransactionsQuery, TransactionsExportFileVm>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public ExportTransactionsQueryHandler(IMapper mapper, ITransactionRepository transactionRepository, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
            _csvExporter = csvExporter;
        }

        public async Task<TransactionsExportFileVm> Handle(ExportTransactionsQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var allTransactions = _mapper.Map<List<TransactionsForExportDto>>(
                (await _transactionRepository.ListAllAsync(request.AccessKey)).OrderBy(x => x.DateTime));

            var fileData = _csvExporter.ExportTransactionsToCsv(allTransactions);

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
