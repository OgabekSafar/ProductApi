using ProductApi.Domain.Entities;
using ProductApi.Infrastructure.Interfaces;

namespace ProductApi.Infrastructure.RepositoriesSqlServer;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ApplicationSqlServerDbContext context) : base(context)
    {
    }
}
