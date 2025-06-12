using Cinema.APIGateway.Domain.Models.Catalog;

namespace Cinema.APIGateway.Domain.Infrastructure.Repositories;

public interface ICatalogRepository
{
    public Task<IEnumerable<MovieModel>> SearchMoviesAsync(SearchMoviesModel searchMoviesModel);
}
