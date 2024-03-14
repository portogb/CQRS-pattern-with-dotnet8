using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cities.API.Filters
{
    public sealed class ValidationFilter(ILogger logger) : IActionFilter
    {
        private readonly ILogger _logger = logger;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"""Action '{context.ActionDescriptor.DisplayName}' has completed""");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                List<string> errors = context
                    .ModelState
                    .SelectMany(m => m.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                context.Result = new BadRequestObjectResult(errors);
            }
        }
    }
}
