using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Cinema.APIGateway.Domain.Dtos.Requests.Catalog;

/// <summary>
/// DTO para requisição de busca de filmes no catálogo.
/// </summary>
/// <remarks>
/// Utilizado para filtrar filmes por termo de pesquisa e ano de lançamento.
/// </remarks>
[ExcludeFromCodeCoverage]
public record GetMoviesRequestDto
{
    /// <summary>
    /// Termo de pesquisa para filtrar os filmes (ex: título, parte do nome, etc).
    /// </summary>
    [JsonProperty("termoPesquisa")]
    public required string TermSearch { get; set; }

    /// <summary>
    /// Ano de lançamento dos filmes a serem filtrados.
    /// </summary>
    [JsonProperty("anoLancamento")]
    public int PremiereYear { get; set; }
}
