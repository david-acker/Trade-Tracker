using System.Collections.Generic;
using TradeTracker.Application.Common.Enums;
using TradeTracker.Application.Interfaces.Resources.Requests;

namespace TradeTracker.Application.Common.Models.Resources.Requests
{
    public class NullSymbolSelection : ISymbolSelection
    {
        public List<string> Symbols { get; set; } = new List<string>();
        public SelectionType Type { get; set; } = SelectionType.NotSpecified;   
    }
}