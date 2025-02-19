using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApi.Domain.Entities;

public class Product
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public decimal DiscountPercentage { get; set; }
    public long CategoryId { get; set; }
    public string Category { get; set; }
    public long BrandId { get; set; }
    public string Brand { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

}
