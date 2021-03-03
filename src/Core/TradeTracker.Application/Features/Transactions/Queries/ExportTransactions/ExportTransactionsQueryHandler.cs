using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Interfaces.Infrastructure;
using TradeTracker.Application.Interfaces.Persistence;

namespace TradeTracker.Application.Features.Transactions.Queries.ExportTransactions
{
    public class ExportTransactionsQueryHandler : IRequestHandler<ExportTransactionsQuery, TransactionsExportFileVm>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public ExportTransactionsQueryHandler(IMapper mapper, ITransactionRepository transactionRepository, ICsvExporter csvExporter)
        {
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
            _transactionRepository = transactionRepository
                ?? throw new ArgumentNullException(nameof(transactionRepository));
            _csvExporter = csvExporter
                ?? throw new ArgumentNullException(nameof(csvExporter));
        }

        public async Task<TransactionsExportFileVm> Handle(ExportTransactionsQuery request, CancellationToken cancellationToken)
        {
            var validator = new ExportTransactionsQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

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