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
using TradeTracker.Application.Requests;

namespace TradeTracker.Application.Features.Transactions.Queries.ExportTransactions
{
    public class ExportTransactionsQueryHandler : 
        ValidatableRequestHandler<ExportTransactionsQuery>,
        IRequestHandler<ExportTransactionsQuery, TransactionsExportFileVm>
    {
        private readonly ICsvExporter _csvExporter;
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _transactionRepository;

        public ExportTransactionsQueryHandler(
            ICsvExporter csvExporter,
            ILoggedInUserService loggedInUserService,
            IMapper mapper, 
            ITransactionRepository transactionRepository)
        {
            _csvExporter = csvExporter;
            _loggedInUserService = loggedInUserService;
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }

        public async Task<TransactionsExportFileVm> Handle(ExportTransactionsQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            Guid userAccessKey = _loggedInUserService.AccessKey;

            var transactions = (await _transactionRepository
                .ListAllAsync(userAccessKey))
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
