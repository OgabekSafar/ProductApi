using ProductApi.Application.Interfaces;
using ProductApi.Application.ViewModels;
using ProductApi.Domain.Entities;
using ProductApi.Infrastructure.Interfaces;

namespace ProductApi.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly ICategoryBrandRepository _categoryBrandRepository;
    private readonly IBrandRepository _brandRepository;
    private readonly IProductRepository _productRepository;

    public CategoryService(ICategoryRepository repository,
                           ICategoryBrandRepository categoryBrandRepository,
                           IBrandRepository brandRepository,
                           IProductRepository productRepository)
    {
        this._repository = repository;
        this._categoryBrandRepository = categoryBrandRepository;
        this._brandRepository = brandRepository;
        this._productRepository = productRepository;
    }

    public async Task<CategoryViewModel> AddAsync(CategoryViewModel entity)
    {
        var model = ConvertToEntity(entity);
        var res = await _repository.AddAsync(model);
        return ConvertToViewModel(res);
    }

    public async Task DeleteAsync(long id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<CategoryViewModel>> GetAllAsync()
    {
        var models = await _repository.GetAllAsync();
        return models.Select(ConvertToViewModel).ToList();
    }

    public async Task<CategoryViewModel> GetByIdAsync(long id)
    {
        var model = await _repository.GetByIdAsync(id);
        return model != null ? ConvertToViewModel(model) : null;
    }

    public async Task UpdateAsync(CategoryViewModel entity)
    {
        var model = await _repository.GetByIdAsync((long)entity.Id);
        if (model == null)
            throw new KeyNotFoundException("Product not found");
        var res = ConvertToEntity(entity);
        await _repository.UpdateAsync(res);
    }

    private CategoryViewModel ConvertToViewModel(Category category) => new CategoryViewModel()
    {
        Id = category.Id,
        Name = category.Name,
    };

    private Category ConvertToEntity(CategoryViewModel viewModel) => new Category()
    {
        Id = (long)viewModel.Id,
        Name = viewModel.Name,
    };
}
