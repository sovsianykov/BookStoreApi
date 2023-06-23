using System.Net;

using System;
namespace MyWebApi.WebApp.Middlewares
{
	public class ExeptionHandlingMiddleware
	{
		public Task Invoke(HttpContext context, RequestDelegate next)
		{
			try  
			{
				return next(context);
			}
			catch (Exception ex)
			{
				var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
				{
					Content = new StringContent(ex.Message)
				};

                return Task.FromResult(response);

            }


        }
	}
}

