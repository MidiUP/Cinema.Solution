using System.Text.Json.Serialization;

namespace Cinema.APIGateway.Domain.Dtos.Requests.Catalog;

public class GetMoviesRequestDto
{
    [JsonPropertyName("termoPesquisa")]
    public required string TermSearch { get; set; }

    [JsonPropertyName("anoLancamento")]
    public int PremiereYear { get; set; }
}
