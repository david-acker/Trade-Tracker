using AutoMapper;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TradeTracker.Business.AuxiliaryModels;
using TradeTracker.Business.Interfaces.Infrastructure;
using TradeTracker.Core.DomainModels.Position;
using TradeTracker.Repository.EntityModels.Position;
using TradeTracker.Repository.Factories;
using TradeTracker.Repository.Helpers;

namespace TradeTracker.Repository.Repositories
{
    public class PositionsRepository : IPositionsRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly IMapper _mapper;

        public PositionsRepository(
            IConnectionFactory connectionFactory,
            IMapper mapper)
        {
            _connectionFactory = connectionFactory;
            _mapper = mapper;
        }

        public async Task<PositionDomainModel> GetAsync(string symbol, string accessKey)
        {
            var sql = $@"SELECT * FROM [Position] WHERE Symbol = @Symbol AND AccessKey = @AccessKey";

            var parameters = new DynamicParameters();
            parameters.Add("@Symbol", symbol);
            parameters.Add("@AccessKey", accessKey);

            using var connection = _connectionFactory.NewConnection();
            await connection.OpenAsync();

            PositionEntityModel position = await connection.QueryFirstOrDefaultAsync<PositionEntityModel>(sql, parameters);

            if (position == null)
            {
                position = new PositionEntityModel
                {
                    Symbol = symbol
                };
            }

            return _mapper.Map<PositionDomainModel>(position);
        }

        public async Task<PaginatedResult<PositionDomainModel>> GetFilteredAsync(PositionFilterDomainModel filterModel, string accessKey)
        {
            var filterEntityModel = _mapper.Map<PositionFilterEntityModel>(filterModel);
            filterEntityModel.AccessKey = accessKey;

            var parameters = CreateParametersForGetFilteredAsync(filterEntityModel);

            using var connection = _connectionFactory.NewConnection();
            await connection.OpenAsync();

            var reader = await connection.QueryMultipleAsync(
                "StoGetFilteredPositions",
                parameters,
                commandType: CommandType.StoredProcedure);

            IEnumerable<PositionEntityModel> positions = reader.Read<PositionEntityModel>().ToList();
            var totalRecordCount = reader.Read<int>().SingleOrDefault();

            return new PaginatedResult<PositionDomainModel>(
                results: _mapper.Map<IEnumerable<PositionDomainModel>>(positions),
                metadata: CreatePaginationMetadata(filterEntityModel, totalRecordCount));
        }

        private DynamicParameters CreateParametersForGetFilteredAsync(PositionFilterEntityModel filterModel)
        {
            var skip = PaginationHelper.CalculateSkip(filterModel);
            var take = PaginationHelper.CalculateTake(filterModel);

            var parameters = new DynamicParameters();
            parameters.Add("@AccessKey", filterModel.AccessKey);
            parameters.Add("@Skip", skip);
            parameters.Add("@Take", take);
            parameters.Add("@PositionType", filterModel.PositionType);
            parameters.Add("@OrderByField", filterModel.OrderByField);
            parameters.Add("@OrderByDirection", filterModel.OrderByDirection);

            return parameters;
        }

        private PaginationMetadata CreatePaginationMetadata(PositionFilterEntityModel filterModel, int totalRecordCount)
        {
            var metadata = new PaginationMetadata
            {
                Page = filterModel.Page,
                PageSize = filterModel.PageSize,
                TotalPages = PaginationHelper.CalculateTotalPages(filterModel, totalRecordCount),
                TotalRecordCount = totalRecordCount
            };

            return metadata;
        }
    }
}
