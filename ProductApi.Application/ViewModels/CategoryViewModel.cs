using ProductApi.Domain.Entities;

namespace ProductApi.Application.ViewModels;

public class CategoryViewModel
{
    public long? Id { get; set; }
    public string Name { get; set; }
    public List<BrandViewModel> BrandViewModels { get; set; }
    public List<ProductViewModel> Products { get; set; }
}
