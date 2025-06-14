using Cinema.Catalog.Domain.Dtos.Results;
using Cinema.Catalog.Domain.Models;

namespace Cinema.Catalog.Domain.Mappers;

public static class MovieMappers
{
    public static MovieModel ToMovieModel(this TmdbSearchMoviesGetResult.ResultItem item)
    {
        return new MovieModel
        {
            Id = item.Id,
            Description = item.Overview,
            Name = item.Title,
            PremiereYear = item.ReleaseDate
        };
    }
}
