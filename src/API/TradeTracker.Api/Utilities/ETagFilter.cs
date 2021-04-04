using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace TradeTracker.Api.Utilities
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class,
        AllowMultiple = false)]
    public class ETagFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var request = context.HttpContext.Request;
            var response = context.HttpContext.Response;

            if (request.Method == HttpMethod.Get.Method
                && response.StatusCode == (int)HttpStatusCode.OK)
            {
                var result = JsonConvert.SerializeObject(context.Result);

                // Will be replaced with a static method containing 
                // the ETag generation implementation
                string generatedETag = String.Empty;

                if (request.Headers.Keys.Contains(HeaderNames.IfNoneMatch))
                {
                    var incomingETag = request
                        .Headers[HeaderNames.IfNoneMatch]
                        .ToString();

                    if (incomingETag.Equals(generatedETag))
                    {
                        context.Result = new StatusCodeResult(
                            (int)HttpStatusCode.NotModified);
                    }
                }
                else
                {
                    response.Headers.Add(HeaderNames.ETag, new [] { generatedETag });
                }

                base.OnActionExecuted(context);
            }
        }
    }
}