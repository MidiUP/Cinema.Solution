namespace Cinema.APIGateway.Domain.Dtos.Responses
{
    public class ErrorResponseDto
    {
        public List<string>? Errors { get; set; }
        public string? Message { get; set; }

        public ErrorResponseDto(List<string> errors, string message)
        {
            Errors = errors;
            Message = message;
        }
        
        public ErrorResponseDto(string error, string message) : this([error], message) { }

        public ErrorResponseDto(string message)
        {
            Message = message;
        }
    }
}
