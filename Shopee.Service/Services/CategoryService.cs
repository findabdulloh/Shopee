using Microsoft.EntityFrameworkCore;
using Shopee.Data.IRepositories;
using Shopee.Data.Repositories;
using Shopee.Domain.Entities;
using Shopee.Service.DTOs.Categories;
using Shopee.Service.Interfaces;

namespace Shopee.Service.Services;

public class CategoryService : ICategoryService
{
    private ICategoryRepository genericRepository = new CategoryRepository();
    public async Task<Category> CreateAsync(CategoryCreationDto dto)
    {
        var entity = await genericRepository.GetAsync(u => u.Name == dto.Name);

        if (entity is not null)
            return null;

        var mapperCategory = new Category()
        {
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = DateTime.UtcNow
        };

        var addedModel = await genericRepository.CreateAsync(mapperCategory);

        await this.genericRepository.SaveChangesAsync();
        return addedModel;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entity = await genericRepository.GetAsync(c => c.Id == id);

        if (entity is null)
            return false;

        await genericRepository.DeleteAsync(c => c.Id == id);
        await this.genericRepository.SaveChangesAsync();
        return true;
    }

    public async Task<List<Category>> GetAllAsync()
        => await this.genericRepository.GetAllASync();

    public async Task<Category> GetByIdAsync(long id)
        => await this.genericRepository.GetAsync(c => c.Id == id);

    public async Task<Category> ModifyAsync(long id, CategoryCreationDto dto)
    {
        var category = await genericRepository.GetAsync(c => c.Id == id);
        if (category is null)
            return null;

        category.Name = dto.Name;
        category.Description = dto.Description;
        category.UpdatedAt = DateTime.UtcNow;

        var updatedCategory = await genericRepository.UpdateAsync(category);
        await this.genericRepository.SaveChangesAsync();
        return updatedCategory;
    }
}
