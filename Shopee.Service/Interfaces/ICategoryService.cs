using Shopee.Domain.Entities;
using Shopee.Service.DTOs.Categories;

namespace Shopee.Service.Interfaces;

public interface ICategoryService
{
    Task<Category> CreateAsync(CategoryCreationDto dto);
    Task<Category> GetByIdAsync(long id);
    Task<bool> DeleteAsync(long id);
    Task<Category> ModifyAsync(long id, CategoryCreationDto dto);
    Task<List<Category>> GetAllAsync();
}