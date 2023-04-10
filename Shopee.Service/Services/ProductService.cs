using Shopee.Data.IRepositories;
using Shopee.Data.Repositories;
using Shopee.Domain.Entities;
using Shopee.Service.DTOs.Products;
using Shopee.Service.Interfaces;

namespace Shopee.Service.Services;

public class ProductService : IProductService
{
    private IProductRepository productRepository = new ProductRepository();
    private ICategoryRepository categoryRepository = new CategoryRepository();

	public async Task<ProductViewDto> CreateAsync(ProductCreationDto dto)
    {
        var entity = await productRepository.GetAsync(u => u.Name == dto.Name);

        if (entity is not null)
            return null;

        var mappedProduct = new Product()
        {
            Description = dto.Description,
            Name = dto.Name,
            CreatedAt = DateTime.UtcNow,
            CategoryId = dto.CategoryId,
            Price = dto.Price,
            SearchTags = dto.SearchTags,
            Count = dto.Count
        };
        if (dto.PhotoUrl is not null)
            mappedProduct.PhotoUrl = dto.PhotoUrl;

        var addedModel = await productRepository.CreateAsync(mappedProduct);

        await this.productRepository.SaveChangesAsync();
        return new ProductViewDto
        {
            SearchTags = addedModel.SearchTags,
            Count = addedModel.Count,
            Description = addedModel.Description,
            Name = addedModel.Name,
            Price = addedModel.Price,
            CreatedAt = addedModel.CreatedAt,
            UpdatedAt = addedModel.UpdatedAt,
            Id = addedModel.Id,
            PhotoUrl = addedModel.PhotoUrl,
            CategoryName = (await categoryRepository
                .GetAsync(u => u.Id == addedModel.CategoryId))?.Name
        };
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entity = await productRepository.GetAsync(c => c.Id == id);

        if (entity is null)
            return false;

        await productRepository.DeleteAsync(c => c.Id == id);
        await this.productRepository.SaveChangesAsync();
        return true;
    }

    public async Task<List<ProductViewDto>> GetAllAsync()
    {
        var productViewDtos = new List<ProductViewDto>();

        foreach (var item in await productRepository.GetAllASync())
        {
            productViewDtos.Add(new ProductViewDto
            {
                SearchTags = item.SearchTags,
                Count = item.Count,
                Description = item.Description,
                Name = item.Name,
                Price = item.Price,
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt,
                Id = item.Id,
                PhotoUrl = item.PhotoUrl,
                CategoryName = (await categoryRepository
                .GetAsync(u => u.Id == item.CategoryId))?.Name
            });
        }

        return productViewDtos;
    }

    public async Task<ProductViewDto> GetByIdAsync(long id)
    {
        var entity = await productRepository.GetAsync(u => u.Id == id);

        return new ProductViewDto
        {
            SearchTags = entity.SearchTags,
            Count = entity.Count,
            Description = entity.Description,
            Name = entity.Name,
            Price = entity.Price,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            Id = entity.Id,
            PhotoUrl = entity.PhotoUrl,
            CategoryName = (await categoryRepository
                .GetAsync(u => u.Id == entity.CategoryId))?.Name
        };
    }

    public async Task<ProductViewDto> ModifyAsync(long id, ProductCreationDto dto)
    {
        var entity = await productRepository.GetAsync(c => c.Id == id);
        if (entity is null)
            return null;

        entity.Name = dto.Name;
        entity.Description = dto.Description;
        entity.Price = dto.Price;
        entity.UpdatedAt = DateTime.UtcNow;
        entity.CategoryId = dto.CategoryId;
        entity.Count = dto.Count;
        entity.SearchTags = dto.SearchTags;
        entity.PhotoUrl = dto.PhotoUrl;

        var updatedEntity = await productRepository.UpdateAsync(entity);

        await this.productRepository.SaveChangesAsync();

        return new ProductViewDto
        {
            SearchTags = updatedEntity.SearchTags,
            Count = updatedEntity.Count,
            Description = updatedEntity.Description,
            Name = updatedEntity.Name,
            Price = updatedEntity.Price,
            CreatedAt = updatedEntity.CreatedAt,
            UpdatedAt = updatedEntity.UpdatedAt,
            Id = updatedEntity.Id,
            PhotoUrl = updatedEntity.PhotoUrl,
            CategoryName = (await categoryRepository
                .GetAsync(u => u.Id == updatedEntity.CategoryId))?.Name
        }; ;
    }
}
