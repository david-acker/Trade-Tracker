using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Interfaces.Infrastructure;
using TradeTracker.Application.Interfaces.Persistence;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactionsExport
{
    public class GetTransactionsExportQueryHandler : IRequestHandler<GetTransactionsExportQuery, TransactionExportFileVm>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetTransactionsExportQueryHandler(IMapper mapper, ITransactionRepository transactionRepository, ICsvExporter csvExporter)
        {
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
            _transactionRepository = transactionRepository
                ?? throw new ArgumentNullException(nameof(transactionRepository));
            _csvExporter = csvExporter
                ?? throw new ArgumentNullException(nameof(csvExporter));
        }

        public async Task<TransactionExportFileVm> Handle(GetTransactionsExportQuery request, CancellationToken cancellationToken)
        {
            var allTransactions = _mapper.Map<List<TransactionForExportDto>>(
                (await _transactionRepository.ListAllAsync(request.AccessTag)).OrderBy(x => x.DateTime));

            var fileData = _csvExporter.ExportTransactionsToCsv(allTransactions);

            var transactionExportFileDto = new TransactionExportFileVm() 
            { 
                ContentType = "text/csv",
                Data = fileData, 
                TransactionExportFileName = $"{Guid.NewGuid()}.csv" 
            };

            return transactionExportFileDto;
        }
    }
}
