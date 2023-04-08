using Shopee.Domain.Entities;
using System.Linq.Expressions;

namespace Shopee.Data.IRepositories;

public interface IOrderRepostory
{
    Task<Order> CreateAsync(Order order);
    Task<bool> DeleteAsync(Expression<Func<Order, bool>> expression);
    Task<Order> GetAsync(Expression<Func<Order, bool>> expression);
    Task<List<Order>> GetAllASync(Expression<Func<Order, bool>> expression = null);
}
