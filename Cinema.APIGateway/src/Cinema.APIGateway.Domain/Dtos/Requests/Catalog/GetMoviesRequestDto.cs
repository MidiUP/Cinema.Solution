using Newtonsoft.Json;

namespace Cinema.APIGateway.Domain.Dtos.Requests.Catalog;

public record GetMoviesRequestDto
{
    [JsonProperty("termoPesquisa")]
    public required string TermSearch { get; set; }

    [JsonProperty("anoLancamento")]
    public int PremiereYear { get; set; }
}
