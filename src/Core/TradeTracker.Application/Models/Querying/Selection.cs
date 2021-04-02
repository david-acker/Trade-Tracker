using System;
using System.Collections.Generic;
using System.Linq;
using TradeTracker.Application.Enums;

namespace TradeTracker.Api.Models.Querying
{
    public class Selection
    {
        public List<string> Values { get; set; } = new List<string>();
        public SelectionType Type { get; set; } = SelectionType.NotSpecified;

        public Selection(List<string> values, SelectionType type)
        {
            Values = values;
            Type = type;
        }
        
        public Selection(string selectionString)
        {
            Values = extractValues(selectionString);
            Type = extractType(selectionString);
        }

        private List<string> extractValues(string selectionString)
        {
            var cleanedSelectionString = selectionString.Trim();

            var valuesString = cleanedSelectionString
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)[0]
                .Trim();

            return valuesString
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Where(s => !String.IsNullOrWhiteSpace(s))
                .Select(s => s.Trim())
                .ToList();
        }

        private SelectionType extractType(string selectionString)
        {
            var cleanedSelectionString = selectionString.Trim();

            var typeString = cleanedSelectionString
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]
                .Trim();
        
            var type = SelectionType.NotSpecified;
            Enum.TryParse(typeString, true, out type);

            return type;
        }      
    }
}