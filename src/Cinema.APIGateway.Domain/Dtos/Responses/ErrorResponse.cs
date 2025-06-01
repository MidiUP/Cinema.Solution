namespace Cinema.APIGateway.Domain.Dtos.Responses
{
    public class ErrorResponse
    {
        public List<string>? Errors { get; set; }

        public ErrorResponse(List<string> errors)
        {
            Errors = errors;
        }

        public ErrorResponse(string error) : this([error]) { }
    }
}
