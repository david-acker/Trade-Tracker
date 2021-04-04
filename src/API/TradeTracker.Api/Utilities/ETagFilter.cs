using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TradeTracker.Api.Utilities
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class,
        AllowMultiple = false)]
    public class ETagFilter : ActionFilterAttribute
    {
        
    }
}