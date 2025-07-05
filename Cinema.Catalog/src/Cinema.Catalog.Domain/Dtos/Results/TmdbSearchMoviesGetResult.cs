using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Cinema.Catalog.Domain.Dtos.Results;

/// <summary>
/// Modelo de retorno para a rota <c>/search/movie</c> da API TMDb.
/// </summary>
/// <remarks>
/// Representa exatamente o formato de resposta da rota <c>search/movie</c> da TMDb API,
/// conforme a documenta��o oficial: https://developers.themoviedb.org/3/search/search-movies.
/// <para>
/// Utilizado como retorno do m�todo <see cref="ITmdbApi.SearchMovies"/>.
/// A deserializa��o do resultado � feita automaticamente pelo Refit para esta estrutura.
/// </para>
/// <para>
/// Esta classe � interna ao adaptador; os dados s�o mapeados para <see cref="Models.Filme"/>
/// para exposi��o externa. O mapeamento ocorre em <see cref="TmdbAdapter.GetFilmesAsync"/>.
/// </para>
/// </remarks>
[ExcludeFromCodeCoverage]
public class TmdbSearchMoviesGetResult
{
    /// <summary>
    /// Representa um item individual do resultado da busca de filmes.
    /// </summary>
    /// <remarks>
    /// Cada inst�ncia corresponde a um filme retornado pela busca na API TMDb.
    /// </remarks>
    public class ResultItem
    {
        /// <summary>
        /// Identificador �nico do filme no TMDb.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// T�tulo do filme.
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// Sinopse ou descri��o do filme.
        /// </summary>
        public string Overview { get; set; } = null!;

        /// <summary>
        /// Data de lan�amento do filme (pode ser nula).
        /// </summary>
        [JsonProperty(PropertyName = "release_date")]
        public DateTimeOffset? ReleaseDate { get; set; }
    }

    /// <summary>
    /// Lista de filmes retornados pela busca.
    /// </summary>
    /// <remarks>
    /// Cada item da lista representa um filme encontrado conforme os crit�rios de busca informados.
    /// </remarks>
    public IEnumerable<ResultItem> Results { get; set; } = null!;
}
