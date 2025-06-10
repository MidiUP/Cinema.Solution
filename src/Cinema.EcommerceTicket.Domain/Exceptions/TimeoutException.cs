using System.Net;

namespace Cinema.EcommerceTicket.Domain.Exceptions;

public class TimeoutException : CinemaEcommerceTicketException
{
    const string ERROR_EXCEPTION_MESSAGE = "Timeout Exception";
    public override int ERROR_CODE => (int) HttpStatusCode.RequestTimeout;
    public TimeoutException() : base([], ERROR_EXCEPTION_MESSAGE) { }

}
