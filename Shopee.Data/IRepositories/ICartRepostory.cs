using Shopee.Domain.Entities;
using System.Linq.Expressions;

namespace Shopee.Data.IRepositories; 
public interface ICartRepostory 
{
    Task<Cart> CreateAsync(Cart cart);
    Task<Cart> UpdateAsync(Cart cart);
    Task<bool> DeleteAsync(Expression<Func<Cart, bool>> expression);
    Task<Cart> GetAsync(Expression<Func<Cart, bool>> expression);
    Task<List<Cart>> GetAllASync(Expression<Func<Cart, bool>> expression = null);
}   
