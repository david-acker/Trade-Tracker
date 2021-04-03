using System.Collections.Generic;
using System.Linq;
using TradeTracker.Application.Common.Enums;
using TradeTracker.Application.Common.Helpers;
using TradeTracker.Application.Interfaces.Resources.Requests;

namespace TradeTracker.Application.Common.Models.Resources.Requests
{
    public class SymbolSelection : ISymbolSelection
    {
        public List<string> Symbols { get; set; } = new List<string>();
        public SelectionType Type { get; set; } = SelectionType.NotSpecified;

        public SymbolSelection(List<string> symbols, SelectionType type)
        {
            Symbols = symbols;
            Type = type;
        }
        
        public SymbolSelection(string symbolSelectionString)
        {
            Symbols = SymbolSelectionParser.extractSymbols(symbolSelectionString)
                .Select(s => s.ToUpper())
                .ToList();
                
            Type = SymbolSelectionParser.extractSelectionType(symbolSelectionString);
        }    
    }
}