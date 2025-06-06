using Cinema.APIGateway.Domain.Dtos.Responses;
using Cinema.APIGateway.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Cinema.APIGateway.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    const string SERVER_ERROR_MESSAGE = "Ocorreu um inesperado. Por favor tente novamente mais tarde";

    public void OnException(ExceptionContext context)
    {
        if (context.Exception is CinemaAPIGatewayException exception)
            HandleResultException(context, exception.ERROR_CODE);
        else
            HandleUnknownException(context);
    }

    private static void HandleResultException(ExceptionContext context, int statusCode)
    {
        var exception = context.Exception;

        if(exception is CinemaAPIGatewayException cinemaAPIGatewayException)
            context.Result = new ObjectResult(new ErrorResponseDto(cinemaAPIGatewayException.Errors ?? [], cinemaAPIGatewayException.Message));
        else
            context.Result = new ObjectResult(new ErrorResponseDto(SERVER_ERROR_MESSAGE));
            
        context.HttpContext.Response.StatusCode = statusCode;
    }

    private static void HandleUnknownException(ExceptionContext context)
    {
        HandleResultException(context, (int)HttpStatusCode.InternalServerError);
    }

}
