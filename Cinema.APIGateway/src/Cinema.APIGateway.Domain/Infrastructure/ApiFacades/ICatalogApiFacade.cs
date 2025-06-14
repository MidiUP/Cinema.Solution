using Cinema.APIGateway.Domain.Models.Catalog;

namespace Cinema.APIGateway.Domain.Infrastructure.ApiAdapters;

public interface ICatalogApiFacade
{
    public Task<IEnumerable<MovieModel>> GetMoviesAsync(SearchMoviesModel searchMoviesModel, CancellationToken cancellationToken);
}
