using ProductApi.Infrastructure.Interfaces;
using ProductApi.Infrastructure.RepositoriesSqlServer;

namespace ProductApi.Server.Configurations;

public static class RepositoryConfiguration
{
    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
    }
}
