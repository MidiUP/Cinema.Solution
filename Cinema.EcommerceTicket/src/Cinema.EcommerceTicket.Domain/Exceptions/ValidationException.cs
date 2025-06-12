﻿using System.Net;

namespace Cinema.EcommerceTicket.Domain.Exceptions;

public class ValidationException : CinemaEcommerceTicketException
{
    const string ERROR_EXCEPTION_MESSAGE = "Validation Exception";
    public override int ERROR_CODE => (int)HttpStatusCode.BadRequest;
    public ValidationException(List<string> errors) : base(errors, ERROR_EXCEPTION_MESSAGE) { }
    public ValidationException(string error) : base([error], ERROR_EXCEPTION_MESSAGE) { }
}
