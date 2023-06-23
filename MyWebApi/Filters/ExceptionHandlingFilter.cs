using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


using System;
namespace MyWebApi.WebApp.Filters
{
    public class ExceptionHandlingFilter : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            var ex = context.Exception;
            context.Result = new ObjectResult(ex.Message)
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;
            return Task.CompletedTask;

        }

    }
}

