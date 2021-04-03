using TradeTracker.Application.Common.Models.Resources.Requests;
using TradeTracker.Application.Interfaces.Resources.Requests;
using TradeTracker.Application.ResourceParameters;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Application.Common.Models.Resources.Parameters.Positions
{
    public class UnpagedPositionsResourceParameters : IUnpagedResourceParameters
    {
        public IPositionOrderBy OrderBy { get; set; } = new NullPositionOrderBy();
        public ISymbolSelection SymbolSelection { get; set; } = new NullSymbolSelection();
        public ExposureType ExposureType { get; set; } = ExposureType.NotSpecified;
    }
}