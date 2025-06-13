using Cinema.Catalog.Domain.Models;

namespace Cinema.Catalog.Domain.Infrastructure.ApiFacades;

public interface ITmdbApiFacade
{
    public Task<DetailsMovieModel> GetDetailsMovieAsync(int movieId, CancellationToken cancellationToken = default);
    public Task<IEnumerable<MovieModel>> GetMoviesAsync(SearchMoviesModel searchMoviesModel, CancellationToken cancellationToken = default);
}
