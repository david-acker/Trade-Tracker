using System.Collections.Generic;
using TradeTracker.Application.Common.Enums;

namespace TradeTracker.Application.Interfaces.Resources.Requests
{
    public interface ISymbolSelection
    {
        List<string> Symbols { get; set; } 
        SelectionType Type { get; set; }
    }
}