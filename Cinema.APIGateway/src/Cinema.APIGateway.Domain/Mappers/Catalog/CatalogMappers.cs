using Cinema.APIGateway.Domain.Dtos.Requests.Catalog;
using Cinema.APIGateway.Domain.Dtos.Responses.Catalog;
using Cinema.APIGateway.Domain.Models.Catalog;

namespace Cinema.APIGateway.Domain.Mappers.Catalog;

/// <summary>
/// Métodos de extensão para mapear objetos relacionados ao catálogo de filmes.
/// </summary>
/// <remarks>
/// Fornece conversões entre DTOs de requisição/resposta e modelos de domínio para operações de catálogo.
/// </remarks>
public static class CatalogMappers
{
    /// <summary>
    /// Converte um <see cref="GetMoviesRequestDto"/> em um <see cref="SearchMoviesModel"/>.
    /// </summary>
    /// <param name="request">DTO de requisição de busca de filmes.</param>
    /// <returns>Instância de <see cref="SearchMoviesModel"/> preenchida com os dados do DTO.</returns>
    public static SearchMoviesModel MapToSearchMoviesModel(this GetMoviesRequestDto request)
    {
        return new SearchMoviesModel
        {
            TermSearch = request.TermSearch,
            PremiereYear = request.PremiereYear
        };
    }

    /// <summary>
    /// Converte um <see cref="MovieModel"/> em um <see cref="GetMoviesResponseDto"/>.
    /// </summary>
    /// <param name="movie">Modelo de domínio do filme.</param>
    /// <returns>Instância de <see cref="GetMoviesResponseDto"/> preenchida com os dados do modelo.</returns>
    public static GetMoviesResponseDto MapToGetMoviesResponseDto(this MovieModel movie)
    {
        return new GetMoviesResponseDto
        {
            Id = movie.Id,
            Name = movie.Name,
            Description = movie.Description,
            PremiereYear = movie?.PremiereYear
        };
    }
}

