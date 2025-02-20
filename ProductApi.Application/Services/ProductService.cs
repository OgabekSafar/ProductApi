using ProductApi.Application.Interfaces;
using ProductApi.Application.ViewModels;
using ProductApi.Domain.Entities;
using ProductApi.Infrastructure.Interfaces;

namespace ProductApi.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly IBrandRepository _brandRepository;
    private readonly ICategoryRepository _categoryRepository;

    public ProductService(IProductRepository repository,
                          IBrandRepository brandRepository,
                          ICategoryRepository categoryRepository)
    {
        this._repository = repository;
        this._brandRepository = brandRepository;
        this._categoryRepository = categoryRepository;
    }
    public async Task<ProductViewModel> AddAsync(ProductViewModel entity)
    {
        var model = ConvertToEntity(entity);
        var res = await _repository.AddAsync(model);
        return ConvertToViewModel(res);
    }

    public async Task DeleteAsync(long id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
    {
        var models = await _repository.GetAllAsync();
        return models.Select(ConvertToViewModel).ToList();
    }

    public async Task<ProductViewModel> GetByIdAsync(long id)
    {
        var model = await _repository.GetByIdAsync(id);
        return model != null ? ConvertToViewModel(model) : null;
    }

    public async Task UpdateAsync(ProductViewModel entity)
    {
        var model = await _repository.GetByIdAsync((long)entity.Id);
        if (model == null)
            throw new KeyNotFoundException("Product not found");
        var res = ConvertToEntity(entity);
        await _repository.UpdateAsync(res);
    }

    private Product ConvertToEntity(ProductViewModel viewModel) => new Product()
    {
        Id = (long)viewModel.Id,
        Name = viewModel.Name,
        Description = viewModel.Description,
        Price = viewModel.Price,
        Quantity = viewModel.Quantity,
        CreatedAt = viewModel.CreatedAt,
        UpdatedAt = viewModel.UpdatedAt,
        DiscountPercentage = viewModel.DiscountPercentage,
        BrandId = viewModel.BrandId,
        CategoryId = viewModel.CategoryId,
    };

    private ProductViewModel ConvertToViewModel(Product entity) => new ProductViewModel()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        Price = entity.Price,
        Quantity = entity.Quantity,
        CreatedAt = entity.CreatedAt,
        UpdatedAt = entity.UpdatedAt,
        DiscountPercentage = entity.DiscountPercentage,
        BrandId = entity.BrandId,
        CategoryId = entity.CategoryId,
        Brand = FindByIdBrand(entity.BrandId),
        Category = FindByIdCategory(entity.CategoryId),
    };

    private BrandViewModel FindByIdBrand(long brandId)
    {
        var model = _brandRepository.GetByIdAsync(brandId).Result;
        return new BrandViewModel()
        {
            Id = brandId,
            Name = model.Name,
        };
    }

    private CategoryViewModel FindByIdCategory(long categoryId)
    {
        var entity = _categoryRepository.GetByIdAsync(categoryId).Result;
        return new CategoryViewModel()
        {
            Id = categoryId,
            Name = entity.Name,
        };
    }
}