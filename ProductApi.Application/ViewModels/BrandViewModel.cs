using ProductApi.Domain.Entities;

namespace ProductApi.Application.ViewModels;

public class BrandViewModel
{
    public long? Id { get; set; }
    public string Name { get; set; }
    public List<CategoryViewModel> Categorys { get; set; }
    public List<ProductViewModel> Products { get; set; }
}
