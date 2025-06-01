using Cinema.APIGateway.Domain.Dtos.Requests.EcommerceTicket;
using Cinema.APIGateway.Domain.Dtos.Responses;
using Cinema.APIGateway.Domain.Exceptions;
using Cinema.APIGateway.Domain.Models.Catalog;
using Cinema.APIGateway.Domain.Services.EcommerceTicket.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.APIGateway.API.Controllers.V1;

public class EcommerceTicketController(IEcommerceTicketService ecommerceTicketService) : CinemaApiGatewayControllerBase
{
    public readonly IEcommerceTicketService _ecommerceTicketService = ecommerceTicketService;

    [HttpPost("/check-in")]
    [ProducesResponseType<MovieModel>(StatusCodes.Status202Accepted)]
    [ProducesResponseType<MovieModel>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ErrorResponseDto>(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> CheckInTicketAsync([FromBody] CreateCheckInRequestDto createCheckInRequest)
    {
        await _ecommerceTicketService.AddQueueCheckInMovieAsync(createCheckInRequest.MovieId);
        var resposta = new ObjectResult(null)
        {
            StatusCode = 202
        };
        return resposta;
    }
}
