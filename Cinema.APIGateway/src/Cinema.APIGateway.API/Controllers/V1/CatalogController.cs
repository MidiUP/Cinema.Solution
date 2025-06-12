using Cinema.APIGateway.API.Attributes;
using Cinema.APIGateway.Domain.Dtos.Requests.Catalog;
using Cinema.APIGateway.Domain.Dtos.Responses;
using Cinema.APIGateway.Domain.Mappers.Catalog;
using Cinema.APIGateway.Domain.Models.Catalog;
using Cinema.APIGateway.Domain.Services.Catalog.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.APIGateway.API.Controllers.V1;

[ApiVersion("1")]
[CinemaApiGatewayVersionedRoute("1")]
public class CatalogController(ICatalogService catalogService) : CinemaApiGatewayControllerBase
{
    private readonly ICatalogService _catalogService = catalogService;

    [HttpGet("movies")]
    [ProducesResponseType<MovieModel>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType<ErrorResponseDto>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ErrorResponseDto>(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetMoviesAsync([FromQuery] GetMoviesRequestDto getMoviesRequest)
    {
        var searchMoviesModel = getMoviesRequest.MapToSearchMoviesModel();

        var movies = await _catalogService.SearchMoviesAsync(searchMoviesModel);

        if (movies is null)
            return NoContent();

        return Ok(movies);
    }
}
