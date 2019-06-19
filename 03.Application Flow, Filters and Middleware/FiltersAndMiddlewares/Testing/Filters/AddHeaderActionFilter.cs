using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testing.Filters
{
    public class AddHeaderActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.Headers.Add("X-username", context.HttpContext.User?.Identity?.Name ?? "Not logged in");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //context.Result = new ContentResult() { Content = "Hello!" }; 

            context.HttpContext.Response.Headers.Add("X-Server", "my server");
        }
    }
}