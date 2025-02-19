using Microsoft.EntityFrameworkCore;
using ProductApi.Infrastructure;

namespace ProductApi.Server.Configurations;

public static class DatabaseConfiguration
{
    public static void ConfigureDatabase(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ApplicationSqlServerDbContext>(options =>
          options.UseSqlServer(connectionString));
    }
}
