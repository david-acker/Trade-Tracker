using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TradeTracker.Api.Test.Base
{
    public class ControllerTestBase
    {
        public ControllerTestBase()
        {
        }

        protected void SetRequestHeader(ControllerBase controller, string headerKey, string headerValue)
        {
            PrepareControllerContext(controller);

            controller.ControllerContext.HttpContext.Request.Headers[headerKey] = headerValue;
        }

        public void PrepareControllerContext(ControllerBase controller)
        {
            if (controller.ControllerContext == null)
            {
                controller.ControllerContext = new ControllerContext();
            }

            if (controller.ControllerContext.HttpContext == null)
            {
                controller.ControllerContext.HttpContext = new DefaultHttpContext();
            }
        }
    }
}
