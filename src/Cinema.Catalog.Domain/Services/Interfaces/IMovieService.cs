using Cinema.Catalog.Domain.Models;

namespace Cinema.Catalog.Domain.Services.Interfaces
{
    public interface IMovieService
    {
        public Task<DetailsMovieModel> GetDetailsMovieAsync(int movieId);
        public Task<IEnumerable<MovieModel>> GetMoviesAsync(SearchMoviesModel searchMoviesModel);
    }
}
