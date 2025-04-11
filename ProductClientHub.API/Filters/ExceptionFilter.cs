using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is ProductsClientHubException productsClientHubException)
            {
                context.HttpContext.Response.StatusCode = (int)productsClientHubException.GetHttpStatusCode();

                context.Result = new ObjectResult(new ResponseErrorMessagesJson(productsClientHubException.GetErros()));
            }
            else
            {
                TrowUnknowError(context);
            }
        }

        private void TrowUnknowError(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorMessagesJson("Unknoew Error"));
                
        }

    }
}
