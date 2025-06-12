using Cinema.APIGateway.Domain.Models.Catalog;

namespace Cinema.APIGateway.Domain.Services.Catalog.Interfaces;

public interface ICatalogService
{
    Task<IEnumerable<MovieModel>> SearchMoviesAsync(SearchMoviesModel searchMoviesModel);
}
