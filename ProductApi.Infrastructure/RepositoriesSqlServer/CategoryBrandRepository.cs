using ProductApi.Domain.Entities;
using ProductApi.Infrastructure.Interfaces;
using ProductApi.Infrastructure.RepositoriesSqlServer;

namespace ProductApi.Infrastructure.Repositories;

public class CategoryBrandRepository : Repository<CategoryBrand>, ICategoryBrandRepository
{
    public CategoryBrandRepository(ApplicationSqlServerDbContext context) : base(context)
    {
    }
}
