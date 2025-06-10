using Microsoft.AspNetCore.Mvc;

namespace Cinema.EcommerceTicket.API.Attributes;

public class CinemaApiGatewayVersionedRouteAttribute(string version) : RouteAttribute($"api/v{version}/[controller]") { }
