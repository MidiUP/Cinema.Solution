using Cinema.APIGateway.Domain.Exceptions;
using Cinema.APIGateway.Domain.Infrastructure.Repositories;
using Cinema.APIGateway.Domain.Models.Catalog;
using Cinema.APIGateway.Domain.Services.Catalog.Interfaces;

namespace Cinema.APIGateway.Domain.Services.Catalog;

public class CatalogService(ICatalogRepository catalogRepository) : ICatalogService
{
    public readonly ICatalogRepository _catalogRepository = catalogRepository;

    public async Task<IEnumerable<MovieModel>> SearchMoviesAsync(SearchMoviesModel searchMoviesModel)
    {
        var validationSearchModel = searchMoviesModel.Validation();
        if (!validationSearchModel.IsValid)
            throw new ValidationException(validationSearchModel.Errors);

        return await _catalogRepository.SearchMoviesAsync(searchMoviesModel);
    }
}
