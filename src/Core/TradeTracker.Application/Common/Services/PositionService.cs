using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Interfaces;
using TradeTracker.Application.Common.Interfaces.Persistence.Positions;
using TradeTracker.Application.Common.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Interfaces;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Application.Common.Services
{
    public class PositionService : IPositionService
    {
        private readonly IAuthenticatedPositionRepository _authenticatedPositionRepository;
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly ILogger<PositionService> _logger;

        public PositionService(
            IAuthenticatedPositionRepository authenticatedPositionRepository,
            IAuthenticatedTransactionRepository authenticatedTransactionRepository,
            ILoggedInUserService loggedInUserService,
            ILogger<PositionService> logger)
        {
            _authenticatedPositionRepository = authenticatedPositionRepository;
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
            _loggedInUserService = loggedInUserService;
            _logger = logger;
        }

        public async Task HandleNewPosition(Position position)
        {
            if (position.IsClosed)
            {
                await AddPosition(position);
            } 
        }

        public async Task HandleExistingPosition(Position position)
        {
            if (position.IsClosed)
            {
                await UpdatePosition(position);
            }
            else
            {
                await ClosePosition(position);
            }        
        }

        public async Task AddPosition(Position position)
        {
            await _authenticatedPositionRepository.AddAsync(position);
            _logger.LogInformation($"PositionService: {nameof(AddPosition)} - Added position for {position.Symbol}.");
        }

        public async Task UpdatePosition(Position position)
        {
            await _authenticatedPositionRepository.UpdateAsync(position);
            _logger.LogInformation($"PositionService: {nameof(UpdatePosition)} - Updating position for {position.Symbol}.");
        }

        public async Task ClosePosition(Position position)
        {
            await _authenticatedPositionRepository.DeleteAsync(position);
            _logger.LogInformation($"PositionService: {nameof(ClosePosition)} - Closed position for {position.Symbol}.");
        }

        public async Task AttachToPosition(
            string symbol,
            TransactionType transactionType,
            decimal quantity)
        {
            var position = await _authenticatedPositionRepository
                .GetBySymbolAsync(symbol);

            if (position != null)
            {
                position.Attach(transactionType, quantity);
                await HandleExistingPosition(position);
            }
            else
            {
                position = new Position
                {
                    Symbol = symbol
                };

                position.Attach(transactionType, quantity);
                await HandleNewPosition(position);
            }
        }

        public async Task DetachFromPosition(
            string symbol,
            TransactionType transactionType,
            decimal quantity)
        {
            var position = await _authenticatedPositionRepository
                .GetBySymbolAsync(symbol);

            if (position != null)
            {
                position.Detach(transactionType, quantity);
                await HandleExistingPosition(position);
            }
            else
            {
                position = new Position
                {
                    Symbol = symbol
                };

                position.Detach(transactionType, quantity);
                await HandleNewPosition(position);
            }
        }
    }
}
