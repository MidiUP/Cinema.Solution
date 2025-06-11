using Microsoft.AspNetCore.Mvc;

namespace Cinema.EcommerceTicket.API.Attributes;

public class CinemaEcommerceTicketVersionedRouteAttribute(string version) : RouteAttribute($"api/v{version}/[controller]") { }
