using Shopee.Domain.Entities;
using System.Linq.Expressions;

namespace Shopee.Data.IRepositories;

public interface ICategoryRepository
{
    Task<Category> CreateAsync(Category category);
    Task<Category> UpdateAsync(Category category);
    Task<bool> DeleteAsync(Expression<Func<Category, bool>> expression);
    Task<Category> GetAsync(Expression<Func<Category, bool>> expression);
    Task<List<Category>> GetAllASync(Expression<Func<Category, bool>> expression = null);
    Task<bool> SaveChangesAsync();

}