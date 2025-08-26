using Exception;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters
{
    // Adiciona um MiddleWare de filtros
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

            // Caso a exceção seja conhecida, é lançada com uma mensagem existente no ResourceErrorMessages
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

            // Garante que UnknowException será chamado caso o erro seja desconhecido, impedindo possíveis vazamentos de dados
            else
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Result = new ObjectResult(ResourceErrorMessages.UNKNOW_ERROR);
            }
        }

        // Impede que uma mensagem de erro com dados sensíveis seja lançada
        private void UnknowException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(ResourceErrorMessages.UNKNOW_ERROR);
        }
    }
}
