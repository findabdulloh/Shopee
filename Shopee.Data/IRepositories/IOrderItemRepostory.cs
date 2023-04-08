using Shopee.Domain.Entities;
using System.Linq.Expressions;

namespace Shopee.Data.IRepositories;

public interface IOrderItemRepostory
{
    Task<OrderItem> CreateAsync(OrderItem orderItem);
    Task<OrderItem> UpdateAsync(OrderItem orderItem);
    Task<bool> DeleteAsync(Expression<Func<OrderItem, bool>> expression);
    Task<OrderItem> GetAsync(Expression<Func<OrderItem, bool>> expression);
    Task<List<OrderItem>> GetAllASync(Expression<Func<OrderItem, bool>> expression = null);
}