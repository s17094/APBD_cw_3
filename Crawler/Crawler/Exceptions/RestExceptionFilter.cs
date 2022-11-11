using Microsoft.AspNetCore.Mvc.Filters;

namespace Crawler.Exceptions;

public class RestExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is StudentException exception)
        {
            context.Result = exception.GetResponse();
        }
    }
}