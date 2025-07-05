using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Cinema.APIGateway.API.Attributes;

[ExcludeFromCodeCoverage]
public class CinemaApiGatewayVersionedRouteAttribute(string version) : RouteAttribute($"api/v{version}/[controller]") { }
