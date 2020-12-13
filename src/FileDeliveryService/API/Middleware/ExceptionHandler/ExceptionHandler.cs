using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

using FileDeliveryService.Common.Error.Exceptions;

namespace API.Middleware.ExceptionHandler
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate next;

        public ExceptionHandler(
            RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (AppValidationException e)
            {
                await HandleException(context, e);
            }
            catch (Exception e)
            {
                await HandleException(context, e);
            }
        }

        private Task HandleException(HttpContext context, AppValidationException e)
        {
            string result = JsonConvert.SerializeObject(e.ErrorResponse.Errors);
            int statusCode = (int)e.ErrorResponse.HttpStatusCode;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(result);
        }

        private Task HandleException(HttpContext context, Exception e)
        {
            string result = JsonConvert.SerializeObject(e.Message);
            int statusCode = 500;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(result);
        }
    }
}