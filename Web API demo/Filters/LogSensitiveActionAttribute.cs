﻿using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Web_API_demo.Filters
{
    public class LogSensitiveActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("Sensitive Action Executed!!!");
        }
    }
}
