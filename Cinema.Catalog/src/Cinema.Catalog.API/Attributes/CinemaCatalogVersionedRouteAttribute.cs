using Microsoft.AspNetCore.Mvc;

namespace Cinema.Catalog.API.Attributes;

public class CinemaCatalogVersionedRouteAttribute(string version) : RouteAttribute($"api/v{version}/[controller]") { }
