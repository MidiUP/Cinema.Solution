using Cinema.APIGateway.Domain.Exceptions;
using Cinema.APIGateway.Domain.Infrastructure.ApiFacades;
using Cinema.APIGateway.Domain.Models.Catalog;
using Cinema.APIGateway.Domain.Services.Catalog.Interfaces;

namespace Cinema.APIGateway.Domain.Services.Catalog;

/// <summary>
/// Serviço de domínio responsável pelas operações de catálogo de filmes.
/// </summary>
/// <remarks>
/// Implementa a lógica de negócio para pesquisa de filmes, incluindo validação dos critérios de busca e integração com a API de catálogo.
/// </remarks>
public class CatalogService(ICatalogApiFacade catalogApiFacade) : ICatalogService
{
    private readonly ICatalogApiFacade _catalogApiFacade = catalogApiFacade;

    private readonly TimeSpan DEFAULT_TIMEOUT = TimeSpan.FromSeconds(30);

    /// <summary>
    /// Pesquisa filmes no catálogo de acordo com os critérios informados.
    /// </summary>
    /// <param name="searchMoviesModel">Modelo contendo os parâmetros de pesquisa, como termo e ano de lançamento.</param>
    /// <returns>Uma coleção de <see cref="MovieModel"/> representando os filmes encontrados.</returns>
    /// <exception cref="ValidationException">Lançada quando os critérios de busca são inválidos.</exception>
    public async Task<IEnumerable<MovieModel>> SearchMoviesAsync(SearchMoviesModel searchMoviesModel)
    {
        var cts = new CancellationTokenSource(DEFAULT_TIMEOUT);

        var validationSearchModel = searchMoviesModel.Validation();
        if (!validationSearchModel.IsValid)
            throw new ValidationException(validationSearchModel.Errors);

        return await _catalogApiFacade.GetMoviesAsync(searchMoviesModel, cts.Token);
    }
}

