using Microsoft.EntityFrameworkCore;
using ProductApi.Domain.Entities;

namespace ProductApi.Infrastructure;

public class ApplicationSqlServerDbContext : DbContext
{
    public ApplicationSqlServerDbContext(DbContextOptions<ApplicationSqlServerDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<CategoryBrand> CategoryBrands { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<CategoryBrand>()
            .HasKey(cb => new { cb.CategoryId, cb.BrandId });

        modelBuilder.Entity<CategoryBrand>()
            .HasOne(cb => cb.Category)
            .WithMany(c => c.CategoryBrands)
            .HasForeignKey(cb => cb.CategoryId);

        modelBuilder.Entity<CategoryBrand>()
            .HasOne(cb => cb.Brand)
            .WithMany(b => b.CategoryBrands)
            .HasForeignKey(cb => cb.BrandId);
    }
}
