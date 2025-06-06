using System.Net;

namespace Cinema.APIGateway.Domain.Exceptions;

public class TimeoutException : CinemaAPIGatewayException
{
    const string ERROR_EXCEPTION_MESSAGE = "Timeout Exception";
    public override int ERROR_CODE => (int) HttpStatusCode.RequestTimeout;
    public TimeoutException() : base([], ERROR_EXCEPTION_MESSAGE) { }

}
