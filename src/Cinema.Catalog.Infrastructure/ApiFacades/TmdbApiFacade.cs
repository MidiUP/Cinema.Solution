using Cinema.Catalog.Domain.Dtos.Results;
using Cinema.Catalog.Domain.Infrastructure.ApiFacades;
using Cinema.Catalog.Domain.Mappers;
using Cinema.Catalog.Domain.Models;
using Cinema.Catalog.Domain.Shared;
using Cinema.Catalog.Infrastructure.HttpClients;

namespace Cinema.Catalog.Infrastructure.ApiFacades;

public class TmdbApiFacade(IHttpClientFactory httpClientFactory) : ITmdbApiFacade
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient(Constants.TmdbApi.NAME);
    private readonly string API_KEY = Constants.TmdbApi.API_KEY;
    private readonly string QUERY_LANGUAGE = Constants.TmdbApi.LANGUAGE;

    public async Task<DetailsMovieModel> GetDetailsMovieAsync(int movieId, CancellationToken cancellationToken = default)
    {
        var path = $"movie/{movieId}";
        var queryParams = new Dictionary<string, string>
        {
            ["api_key"] = API_KEY,
            ["language"] = QUERY_LANGUAGE
        };

        return await _httpClient.GetAsync<DetailsMovieModel>(path, queryParams, cancellationToken);
    }

    public async Task<IEnumerable<MovieModel>> GetMoviesAsync(SearchMoviesModel searchMoviesModel, CancellationToken cancellationToken = default)
    {
        var path = "search/movie";
        var queryParams = new Dictionary<string, string>
        {
            ["query"] = searchMoviesModel.TermSearch,
            ["api_key"] = API_KEY,
            ["language"] = QUERY_LANGUAGE
        };

        if (searchMoviesModel.PremiereYear > 0)
            queryParams.Add("year", searchMoviesModel.PremiereYear.ToString());

        var resultRequest = await _httpClient.GetAsync<TmdbSearchMoviesGetResult>(path, queryParams, cancellationToken);
        
        var movies = resultRequest.Results;
        return movies.Select(item => item.ToMovieModel());
    }
}
