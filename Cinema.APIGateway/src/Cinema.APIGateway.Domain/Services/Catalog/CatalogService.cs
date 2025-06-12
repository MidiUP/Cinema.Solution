using Cinema.APIGateway.Domain.Exceptions;
using Cinema.APIGateway.Domain.Infrastructure.Repositories;
using Cinema.APIGateway.Domain.Models.Catalog;
using Cinema.APIGateway.Domain.Services.Catalog.Interfaces;
using Microsoft.Extensions.Logging;

namespace Cinema.APIGateway.Domain.Services.Catalog;

public class CatalogService(ICatalogRepository catalogRepository, ILogger<CatalogService> logger) : ICatalogService
{
    private readonly ICatalogRepository _catalogRepository = catalogRepository;
    private readonly ILogger<CatalogService> _logger = logger;

    public async Task<IEnumerable<MovieModel>> SearchMoviesAsync(SearchMoviesModel searchMoviesModel)
    {
        try
        {
            var validationSearchModel = searchMoviesModel.Validation();
            if (!validationSearchModel.IsValid)
                throw new ValidationException(validationSearchModel.Errors);

            return await _catalogRepository.SearchMoviesAsync(searchMoviesModel);
        }
        catch(ValidationException)
        {
            throw;
        }
        catch (Exception ex) 
        {
            _logger.LogError(ex, "Erro desconhecido ao buscar filmes no catálogo");
            throw;
        }
    }
}
