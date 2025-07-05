using System.Diagnostics.CodeAnalysis;

namespace Cinema.Catalog.Domain.Dtos.Requests;

/// <summary>
/// Modelo de entrada para a rota <c>/search/movie</c> da API TMDb.
/// <para>
/// Representa os par�metros aceitos pela rota <c>search/movie</c> da TMDb API,
/// conforme documenta��o oficial: https://developers.themoviedb.org/3/search/search-movies.
/// </para>
/// <para>
/// Utilizado como par�metro de entrada no m�todo <see cref="ITmdbApi.SearchMovies"/>.
/// </para>
/// <para>
/// Esta classe � interna ao adaptador; os dados s�o mapeados a partir de <see cref="Models.Pesquisa"/>.
/// O mapeamento ocorre em <see cref="TmdbAdapter.GetFilmesAsync"/>.
/// </para>
/// </summary>
[ExcludeFromCodeCoverage]
public class TmdbSearchMoviesGet
{
    /// <summary>
    /// Texto da busca.
    /// </summary>
    public string Query { get; set; } = null!;

    /// <summary>
    /// Chave de API do TMDb.
    /// </summary>
    public string ApiKey { get; set; } = null!;

    /// <summary>
    /// Idioma dos resultados (ex: "pt-BR").
    /// </summary>
    public string Language { get; set; } = null!;

    /// <summary>
    /// Ano de lan�amento para filtrar os resultados.
    /// </summary>
    public int? Year { get; set; } = null!;
}
