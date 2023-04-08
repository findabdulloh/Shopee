using Shopee.Service.DTOs.Carts;
using Shopee.Service.DTOs.OrderItems;

namespace Shopee.Service.Interfaces;

public interface ICartService
{
    Task<CartViewDto> CreateAsync(CartCreationDto dto);
    Task<CartViewDto> GetByUserIdAsync(long userId);
    Task<bool> DeleteAsync(long id);
    Task<CartViewDto> DropOrderItemAsync(long orderItemId);
    Task<CartViewDto> AddOrderItemAsync(OrderItemCreationDto orderItemCreationDto);
    Task<List<CartViewDto>> GetAllAsync();
}