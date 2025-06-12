using Microsoft.AspNetCore.Mvc;

namespace Cinema.APIGateway.API.Attributes;

public class CinemaApiGatewayVersionedRouteAttribute(string version) : RouteAttribute($"api/v{version}/[controller]") { }
