namespace ProductApi.Domain.Entities;

public class CategoryBrand
{
    public long CategoryId { get; set; }
    public Category Category { get; set; }
    public long BrandId { get; set; }
    public Brand Brand { get; set; }
}
