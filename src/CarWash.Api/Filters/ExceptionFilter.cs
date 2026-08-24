using CarWash.Communication.Response;
using CarWash.Exception;
using CarWash.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarWash.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is CarWashException)
        {
            HandleProjectException(context);
        }else
        {
            ThrowUnknowError(context);
        };
    }

    private void HandleProjectException(ExceptionContext context)
    {
        var carWashException = (CarWashException)context.Exception;
        var errorResponse = new ResponseErrorJson(carWashException.GetErrors());

        context.HttpContext.Response.StatusCode = carWashException.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    }

    private void ThrowUnknowError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson(ResourceErrorMessages.UNKNOWN_ERROR);
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);

    }
}
