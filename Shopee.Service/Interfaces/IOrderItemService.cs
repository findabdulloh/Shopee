using Shopee.Domain.Entities;
using Shopee.Service.DTOs.OrderItems;
using Shopee.Service.DTOs.Payments;
using System.Linq.Expressions;

namespace Shopee.Service.Interfaces;

public interface IOrderItemService
{
    Task<OrderItemViewDto> CreateAsync(OrderItemCreationDto dto);
    Task<OrderItemViewDto> GetByIdAsync(long id);
    Task<bool> DeleteAsync(long id);
    Task<OrderItemViewDto> ModifyCountAsync(long id, int newCount);
    Task<List<OrderItemViewDto>> GetAllAsync(Expression<Func<OrderItem, bool>> expression);
}
