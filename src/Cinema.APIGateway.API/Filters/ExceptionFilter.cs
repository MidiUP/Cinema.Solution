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
        if (context.Exception is CinemaAPIGatewayException)
            HandleCinemaApiGatewayException(context);
        else
            HandleUnknownException(context);
    }
    private void HandleCinemaApiGatewayException(ExceptionContext context)
    {
        switch (context.Exception)
        {
            case ValidationException:
                HandleValidationException(context);
                break;
        }

    }

    private void HandleResultException(ExceptionContext context, int statusCode)
    {
        var exception = context.Exception;

        if(exception is CinemaAPIGatewayException cinemaAPIGatewayException)
            context.Result = new ObjectResult(new ErrorResponseDto(cinemaAPIGatewayException.Errors ?? [], cinemaAPIGatewayException.Message));
        else
            context.Result = new ObjectResult(new ErrorResponseDto(SERVER_ERROR_MESSAGE));
            
        context.HttpContext.Response.StatusCode = statusCode;
    }

    private void HandleValidationException(ExceptionContext context)
    {
        HandleResultException(context, (int)HttpStatusCode.BadRequest);
    }

    private void HandleUnknownException(ExceptionContext context)
    {
        HandleResultException(context, (int)HttpStatusCode.InternalServerError);
    }

}
