using System.Text.Json.Serialization;

namespace Cinema.APIGateway.Domain.Dtos.Requests.Catalog;

public class GetMoviesRequest
{
    [JsonPropertyName("termoPesquisa")]
    public required string TermSearch { get; set; }

    [JsonPropertyName("anoLancamento")]
    public required string PremiereYear { get; set; }
}
