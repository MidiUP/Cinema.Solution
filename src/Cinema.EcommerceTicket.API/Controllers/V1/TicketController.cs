using Cinema.EcommerceTicket.API.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.EcommerceTicket.API.Controllers.V1;

[ApiVersion("1.0")]
[CinemaEcommerceTicketVersionedRoute("1")]
public class TicketController() : CinemaEcommerceTicketControllerBase
{
    
}
