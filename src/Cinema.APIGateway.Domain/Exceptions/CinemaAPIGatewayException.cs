namespace Cinema.APIGateway.Domain.Exceptions;

public class CinemaAPIGatewayException : Exception
{
    public List<string>? Errors { get; set; }

    public CinemaAPIGatewayException(List<string> errors, string message) : base(message)
    {
        Errors = errors;
    }

    public CinemaAPIGatewayException(List<string> errors) : this(errors, "Cinema API Gateway Exception") { }

}
