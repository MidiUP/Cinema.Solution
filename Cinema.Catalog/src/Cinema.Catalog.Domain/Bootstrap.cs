using Cinema.Catalog.Domain.Services;
using Cinema.Catalog.Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.Catalog.Domain;

public static class Bootstrap
{
    public static void AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IMovieService, MovieService>();
    }
}
