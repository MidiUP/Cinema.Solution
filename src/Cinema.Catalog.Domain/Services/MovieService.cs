using Cinema.Catalog.Domain.Exceptions;
using Cinema.Catalog.Domain.Infrastructure.ApiFacades;
using Cinema.Catalog.Domain.Models;
using Cinema.Catalog.Domain.Services.Interfaces;

namespace Cinema.Catalog.Domain.Services;

public class MovieService(ITmdbApiFacade tmdbApiFacade) : IMovieService
{
    private readonly ITmdbApiFacade _tmdbApiFacade = tmdbApiFacade;

    private readonly TimeSpan DEFAULT_TIMEOUT = TimeSpan.FromSeconds(30);
    public Task<DetailsMovieModel> GetDetailsMovieAsync(int movieId)
    {
        var cts = new CancellationTokenSource(DEFAULT_TIMEOUT);
        return _tmdbApiFacade.GetDetailsMovieAsync(movieId, cts.Token);
    }

    public Task<IEnumerable<MovieModel>> GetMoviesAsync(SearchMoviesModel searchMoviesModel)
    {
        var validationSearchMoviesModel = searchMoviesModel.Validation();
        if (!validationSearchMoviesModel.IsValid)
            throw new ValidationException(validationSearchMoviesModel.Errors);

        var cts = new CancellationTokenSource(DEFAULT_TIMEOUT);
        return _tmdbApiFacade.GetMoviesAsync(searchMoviesModel, cts.Token);
    }
}
