using Cinema.APIGateway.Domain.Infrastructure.ApiAdapters;
using Cinema.APIGateway.Domain.Models.Catalog;
using Cinema.APIGateway.Domain.Models.EcommerceTicket;
using Cinema.APIGateway.Domain.Shared;
using Cinema.APIGateway.Infrastructure.HttpClients;

namespace Cinema.APIGateway.Infrastructure.ApiFacades;

class CatalogApiFacade(IHttpClientFactory httpClientFactory) : ICatalogApiFacade
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient(Constants.CatalogApi.NAME);

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
