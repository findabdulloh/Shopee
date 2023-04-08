using Shopee.Domain.Entities;
using System.Linq.Expressions;

namespace Shopee.Data.IRepositories;

public interface IProductRepostory
{
    Task<Product> CreateAsync(Product product);
    Task<Product> UpdateAsync(Product product);
    Task<bool> DeleteAsync(Expression<Func<Product, bool>> expression);
    Task<Product> GetAsync(Expression<Func<Product, bool>> expression);
    Task<List<Product>> GetAllASync(Expression<Func<Product, bool>> expression = null);
}