using Cinema.APIGateway.Domain.Dtos.Requests.Catalog;
using Cinema.APIGateway.Domain.Models.Catalog;

namespace Cinema.APIGateway.Domain.Mappers.Catalog;

public static class GetMoviesRequestDtoToSearchMoviesModel
{
    public static SearchMoviesModel MapToSearchMoviesModel(this GetMoviesRequestDto request)
    {
        return new SearchMoviesModel
        {
            TermSearch = request.TermSearch,
            PremiereYear = request.PremiereYear
        };
    }
}
