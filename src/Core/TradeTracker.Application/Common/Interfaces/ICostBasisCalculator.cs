using System.Collections.Generic;
using System.Threading.Tasks;
using TradeTracker.Application.Features.Positions;

namespace TradeTracker.Application.Common.Interfaces
{
    public interface ICostBasisCalculator
    {
        Task<decimal> CalculateAverageCostBasis(string symbol);
        Task<IEnumerable<SourceRelation>> CreateSourceRelations(string symbol);
    }
}
