using Cinema.APIGateway.Domain.Exceptions;
using Cinema.APIGateway.Domain.Infrastructure.ApiAdapters;
using Cinema.APIGateway.Domain.Models.Catalog;
using Cinema.APIGateway.Domain.Services.Catalog.Interfaces;

namespace Cinema.APIGateway.Domain.Services.Catalog;

public class CatalogService(ICatalogApiFacade catalogApiFacade) : ICatalogService
{
    private readonly ICatalogApiFacade _catalogApiFacade = catalogApiFacade;

    private readonly TimeSpan DEFAULT_TIMEOUT = TimeSpan.FromSeconds(30);

    public async Task<IEnumerable<MovieModel>> SearchMoviesAsync(SearchMoviesModel searchMoviesModel)
    {
        var cts = new CancellationTokenSource(DEFAULT_TIMEOUT);

        var validationSearchModel = searchMoviesModel.Validation();
        if (!validationSearchModel.IsValid)
            throw new ValidationException(validationSearchModel.Errors);

        return await _catalogApiFacade.GetMoviesAsync(searchMoviesModel, cts.Token);
    }
}
