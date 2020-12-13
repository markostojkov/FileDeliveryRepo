using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using FileDeliveryService.Contracts.Validators.Interfaces;

namespace API.Filters
{
    public class RequestBodyFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.Request.Method == HttpMethod.Get.ToString())
            {
                await next();
                return;
            }

            IRequestBodyValidator body = context.ActionArguments.Values.OfType<IRequestBodyValidator>().SingleOrDefault(f => f != null);
            if (body == null)
            {
                await next();
                return;
            }

            var validOrError = body.Validate();
            validOrError.ThrowIfErrors();
            await next();
        }
    }
}
