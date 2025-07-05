using Cinema.APIGateway.Domain.Infrastructure.ApiFacades;
using Cinema.APIGateway.Domain.Models.Catalog;
using Cinema.APIGateway.Domain.Shared;
using Cinema.APIGateway.Infrastructure.HttpClients;
using Microsoft.Extensions.Options;

namespace Cinema.APIGateway.Infrastructure.ApiFacades;

class CatalogApiFacade : ICatalogApiFacade
{
    private readonly CatalogApiOptions _catalogApiOptions;
    private readonly HttpClient _httpClient;

    public CatalogApiFacade(IHttpClientFactory httpClientFactory, IOptions<CatalogApiOptions> catalogApiOptions)
    {
        _catalogApiOptions = catalogApiOptions.Value;
        _httpClient = httpClientFactory.CreateClient(_catalogApiOptions.Name);
    }

    public async Task<IEnumerable<MovieModel>> GetMoviesAsync(SearchMoviesModel searchMoviesModel, CancellationToken cancellationToken)
    {
        var path = "v1/movies";
        var queryParams = new Dictionary<string, string>
        {
            ["TermSearch"] = searchMoviesModel.TermSearch
        };

        if(searchMoviesModel.PremiereYear > 0)
            queryParams["PremiereYear"] = searchMoviesModel.PremiereYear.ToString();

        return await _httpClient.GetAsync<IEnumerable<MovieModel>>(path, queryParams, cancellationToken);
    }
}
