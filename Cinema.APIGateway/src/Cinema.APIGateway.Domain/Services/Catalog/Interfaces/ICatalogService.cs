using Cinema.APIGateway.Domain.Models.Catalog;

namespace Cinema.APIGateway.Domain.Services.Catalog.Interfaces;

/// <summary>
/// Interface para o serviço de catálogo de filmes.
/// </summary>
/// <remarks>
/// Define operações de negócio para pesquisa de filmes no catálogo, utilizando critérios de busca como termo e ano de lançamento.
/// </remarks>
public interface ICatalogService
{
    /// <summary>
    /// Pesquisa filmes no catálogo de acordo com os critérios informados.
    /// </summary>
    /// <param name="searchMoviesModel">Modelo contendo os parâmetros de pesquisa, como termo e ano de lançamento.</param>
    /// <returns>Uma coleção de <see cref="MovieModel"/> representando os filmes encontrados.</returns>
    Task<IEnumerable<MovieModel>> SearchMoviesAsync(SearchMoviesModel searchMoviesModel);
}

