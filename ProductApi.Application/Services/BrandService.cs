using ProductApi.Application.Interfaces;
using ProductApi.Application.ViewModels;
using ProductApi.Domain.Entities;
using ProductApi.Infrastructure.Interfaces;

namespace ProductApi.Application.Services;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _repository;
    private readonly ICategoryBrandRepository _categoryBrandRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IProductRepository _productRepository;

    public BrandService(IBrandRepository repository,
                        ICategoryBrandRepository categoryBrandRepository,
                        ICategoryRepository categoryRepository,
                        IProductRepository productRepository)
    {
        this._repository = repository;
        this._categoryBrandRepository = categoryBrandRepository;
        this._categoryRepository = categoryRepository;
        this._productRepository = productRepository;
    }

    public async Task<BrandViewModel> AddAsync(BrandViewModel entity)
    {
        var model = ConvertToEntity(entity);
        var res = await _repository.AddAsync(model);
        return ConvertToViewModel(res);
    }

    public async Task DeleteAsync(long id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<BrandViewModel>> GetAllAsync()
    {
        var models = await _repository.GetAllAsync();
        return models.Select(ConvertToViewModel).ToList();
    }

    public async Task<BrandViewModel> GetByIdAsync(long id)
    {
        var model = await _repository.GetByIdAsync(id);
        return model != null ? ConvertToViewModel(model) : null;
    }

    public async Task UpdateAsync(BrandViewModel entity)
    {
        var model = await _repository.GetByIdAsync((long)entity.Id);
        if (model == null)
            throw new KeyNotFoundException("Product not found");
        var res = ConvertToEntity(entity);
        await _repository.UpdateAsync(res);
    }

    private BrandViewModel ConvertToViewModel(Brand brand) => new BrandViewModel()
    {
        Id = brand.Id,
        Name = brand.Name,
    };

    private Brand ConvertToEntity(BrandViewModel viewModel) => new Brand()
    {
        Id = (long)viewModel.Id,
        Name = viewModel.Name,

    };
}
