using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Middleware
{
    public class HandleException(IProblemDetailsService problemDetailsService) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var problem = new ProblemDetails
            {
                Detail = exception.Message,
                Status = 400,
                Type = "Bad Request",
                Title = "Exception"
            };

            var errorContext = new ProblemDetailsContext
            {
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails = problem
            };
            httpContext.Response.StatusCode = 400;
            await problemDetailsService.WriteAsync(errorContext);
           // await httpContext.Response.WriteAsJsonAsync(problem);
            return true;
        }
    }
}
