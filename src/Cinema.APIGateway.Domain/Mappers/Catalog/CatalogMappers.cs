using Cinema.APIGateway.Domain.Dtos.Requests.Catalog;
using Cinema.APIGateway.Domain.Dtos.Responses.Catalog;
using Cinema.APIGateway.Domain.Models.Catalog;

namespace Cinema.APIGateway.Domain.Mappers.Catalog;

public static class CatalogMappers
{
    public static SearchMoviesModel MapToSearchMoviesModel(this GetMoviesRequestDto request)
    {
        return new SearchMoviesModel
        {
            TermSearch = request.TermSearch,
            PremiereYear = request.PremiereYear
        };
    }

    public static GetMoviesResponseDto MapToGetMoviesResponseDto(this MovieModel movie)
    {
        return new GetMoviesResponseDto
        {
            Id = movie.Id,
            Name = movie.Name,
            Description = movie.Description,
            PremiereYear = movie.PremiereYear
        };
    }
}
