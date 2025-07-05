using Cinema.APIGateway.Domain.Models.Catalog;

namespace Cinema.APIGateway.Domain.Infrastructure.ApiFacades;

/// <summary>
/// Interface para o facade de integração com a API de catálogo de filmes.
/// </summary>
/// <remarks>
/// Define operações para consulta de filmes no catálogo, encapsulando a comunicação com serviços externos de catálogo.
/// </remarks>
public interface ICatalogApiFacade
{
    /// <summary>
    /// Obtém uma lista de filmes do catálogo de acordo com os critérios de pesquisa informados.
    /// </summary>
    /// <param name="searchMoviesModel">Modelo contendo os parâmetros de pesquisa, como termo e ano de lançamento.</param>
    /// <param name="cancellationToken">Token para cancelamento da operação assíncrona.</param>
    /// <returns>Uma coleção de <see cref="MovieModel"/> representando os filmes encontrados.</returns>
    public Task<IEnumerable<MovieModel>> GetMoviesAsync(SearchMoviesModel searchMoviesModel, CancellationToken cancellationToken);
}