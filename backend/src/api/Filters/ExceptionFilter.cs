using Exception;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is RaceException)
            {
                HandleException(context);
            }

            else
            {
                UnknowException(context);
            }
        }
        private void HandleException(ExceptionContext context)
        {
            if (context.Exception is RaceException RaceException)
            {
                var errors = RaceException.Errors;

                context.HttpContext.Response.StatusCode = RaceException.StatusCode;
                context.Result = new ObjectResult(errors);
            }

            else
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Result = new ObjectResult(ResourceErrorMessages.UNKNOW_ERROR);
            }
        }

        private void UnknowException(ExceptionContext context)
        {
            //context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            //context.Result = new ObjectResult(ResourceErrorMessages.UNKNOW_ERROR);
        }
    }
}
