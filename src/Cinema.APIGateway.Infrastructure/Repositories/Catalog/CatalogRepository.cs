using Cinema.APIGateway.Domain.Infrastructure.Repositories;
using Cinema.APIGateway.Domain.Models.Catalog;

namespace Cinema.APIGateway.Infrastructure.Repositories.Catalog;

public class CatalogRepository : ICatalogRepository
{
    public Task<IEnumerable<MovieModel>> SearchMoviesAsync(SearchMoviesModel searchMoviesModel)
    {
        throw new NotImplementedException();
    }
}
