using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Features.Transactions.Commands.UpdateTransaction;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Features.Transactions.Commands.UpdateTransaction
{
    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public UpdateTransactionCommandHandler(IMapper mapper, ITransactionRepository transactionRepository)
        {
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
            _transactionRepository = transactionRepository
                ?? throw new ArgumentNullException(nameof(transactionRepository));
        }

        public async Task<Unit> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {

            var transactionToUpdate = await _transactionRepository.GetByIdAsync(request.AccessTag, request.TransactionId);

            if (transactionToUpdate == null)
            {
                throw new NotFoundException(nameof(Transaction), request.TransactionId);
            }

            var validator = new UpdateTransactionCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, transactionToUpdate, typeof(UpdateTransactionCommand), typeof(Transaction));

            await _transactionRepository.UpdateAsync(transactionToUpdate);

            return Unit.Value;
        }
    }
}