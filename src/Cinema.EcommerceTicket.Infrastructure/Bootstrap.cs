using Cinema.EcommerceTicket.Infrastructure.MongoDb;
using Cinema.EcommerceTicket.Infrastructure.RabbitMq;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.EcommerceTicket.Infrastructure;

public static class Bootstrap
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        AddRepositories(services);
        AddMongoDb(services);
        AddRabbitMq(services);
    }

    private static void AddMongoDb(IServiceCollection services)
    {
        services.AddMongoDb();
    }

    private static void AddRabbitMq(IServiceCollection services)
    {
        services.AddRabbitMq();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        //services.AddScoped<ICatalogRepository, CatalogRepository>();
    }
}
