using Shopee.Domain.Entities;
using Shopee.Domain.Enums;
using Shopee.Service.DTOs.Orders;
using System.Linq.Expressions;

namespace Shopee.Service.Interfaces;

public interface IOrderService
{
    Task<OrderViewDto> CreateAsync(OrderCreationDto dto);
    Task<OrderViewDto> GetByIdAsync(long id);
    Task<bool> DeleteAsync(long id);
    Task<OrderViewDto> ChangeOrderStatusAsync(long orderId, OrderStatus newStatus);
    Task<List<OrderViewDto>> GetAllAsync(Expression<Func<Order, bool>> expression);
}
