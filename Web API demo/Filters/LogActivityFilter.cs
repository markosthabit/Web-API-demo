using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace Web_API_demo.Filters
{
    public class LogActivityFilter : IActionFilter
    {
        private readonly ILogger<LogActivityFilter> _logger;

        public LogActivityFilter(ILogger<LogActivityFilter> logger)
        {
            _logger = logger;    
        }
        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"Executing Action {context.ActionDescriptor.DisplayName} on contoller{context.Controller} with arguments {JsonSerializer.Serialize(context.ActionArguments)}");
        }
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"Action {context.ActionDescriptor.DisplayName} finished execution on controller {context.Controller}");
        }


    }
}
