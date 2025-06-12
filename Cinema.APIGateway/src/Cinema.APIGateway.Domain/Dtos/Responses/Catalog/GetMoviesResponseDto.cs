namespace Cinema.APIGateway.Domain.Dtos.Responses.Catalog;

public record GetMoviesResponseDto
{
    public long Id { get; set; }
    public required string Name { get; set; }
}
