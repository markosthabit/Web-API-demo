using System.Diagnostics;

namespace Web_API_demo.Middlewares
{
    // Profiles the time required to process a request in ms
    public class ProfilingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        
        // first constraint in a middleware is have a request delegate parameter,
        // ie; a way to get into the next stage in the pipeline.
        public ProfilingMiddleware(RequestDelegate next, ILogger<ProfilingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        // second constraint is having an Invoke() or an InvokeAsync()
        // Task does not run on  the main tread on which the web app runs.
        // HttpContext parameters carry all of the request/response data.
        public async Task Invoke(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            await _next(context);
            stopwatch.Stop();
            _logger.LogInformation($"Request '{context.Request.Path}' took '{stopwatch.ElapsedMilliseconds} ms' to execute");        }
    }
}
