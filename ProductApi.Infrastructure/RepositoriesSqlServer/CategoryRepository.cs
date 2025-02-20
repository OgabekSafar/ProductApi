using ProductApi.Domain.Entities;
using ProductApi.Infrastructure.Interfaces;

namespace ProductApi.Infrastructure.RepositoriesSqlServer;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationSqlServerDbContext context) : base(context)
    {
    }
}