using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Cinema.APIGateway.Domain.Dtos.Responses.Catalog;

/// <summary>
/// DTO de resposta para a consulta de filmes no catálogo.
/// </summary>
/// <remarks>
/// Contém as informações detalhadas de um filme retornado pela API de catálogo.
/// </remarks>
[ExcludeFromCodeCoverage]
public record GetMoviesResponseDto
{
    /// <summary>
    /// Identificador do filme no The Moview Database.
    /// </summary>
    [JsonProperty("id")]
    public long Id { get; set; }

    /// <summary>
    /// Nome do filme.
    /// </summary>
    [JsonProperty("nome")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Descricao/Resumo do filme.
    /// </summary>
    [JsonProperty("descricao")]
    public string Description { get; set; } = null!;

    /// <summary>
    /// Data de lancamento do filme.
    /// </summary> 
    [JsonProperty("dataLancamento")]
    public DateTimeOffset PremiereYear { get; set; }
}
