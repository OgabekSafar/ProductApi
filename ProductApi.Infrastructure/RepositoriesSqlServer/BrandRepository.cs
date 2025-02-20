using ProductApi.Domain.Entities;
using ProductApi.Infrastructure.Interfaces;

namespace ProductApi.Infrastructure.RepositoriesSqlServer;

public class BrandRepository : Repository<Brand>, IBrandRepository
{
    public BrandRepository(ApplicationSqlServerDbContext context) : base(context)
    {
    }
}
