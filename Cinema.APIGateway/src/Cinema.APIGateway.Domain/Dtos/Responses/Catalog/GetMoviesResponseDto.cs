using Newtonsoft.Json;

namespace Cinema.APIGateway.Domain.Dtos.Responses.Catalog;

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
