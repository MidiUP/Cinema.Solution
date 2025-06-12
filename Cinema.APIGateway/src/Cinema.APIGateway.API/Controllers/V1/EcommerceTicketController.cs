using Cinema.APIGateway.API.Attributes;
using Cinema.APIGateway.Domain.Dtos.Requests.EcommerceTicket;
using Cinema.APIGateway.Domain.Mappers.EcommerceTicket;
using Cinema.APIGateway.Domain.Dtos.Responses;
using Cinema.APIGateway.Domain.Models.Catalog;
using Cinema.APIGateway.Domain.Services.EcommerceTicket.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Cinema.APIGateway.Domain.Models.EcommerceTicket;
using Cinema.APIGateway.Domain.Dtos.Responses.EcommerceTicket;

namespace Cinema.APIGateway.API.Controllers.V1;

[ApiVersion("1.0")]
[CinemaApiGatewayVersionedRoute("1")]
public class EcommerceTicketController(IEcommerceTicketService ecommerceTicketService) : CinemaApiGatewayControllerBase
{
    public readonly IEcommerceTicketService _ecommerceTicketService = ecommerceTicketService;

    [HttpPost("check-in")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType<ErrorResponseDto>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ErrorResponseDto>(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> CheckInTicketAsync([FromBody] CreateCheckInRequestDto createCheckInRequest)
    {
        var checkInModel = createCheckInRequest.MapToCheckInModel();

        await _ecommerceTicketService.AddQueueCheckInMovieAsync(checkInModel);
        return Accepted();
    }

    [HttpGet("tickets/{customerId}")]
    [ProducesResponseType<IEnumerable<GetTicketResponseDto>>(StatusCodes.Status200OK)]
    [ProducesResponseType<ErrorResponseDto>(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetTicketByCustomerIdAsync([FromRoute] int customerId)
    {
        var response = await _ecommerceTicketService.GetTicketsByCustomerIdAsync(customerId);
        if(response is null || !response.Any())
            return NoContent();

        return Ok(response);
    }
}
