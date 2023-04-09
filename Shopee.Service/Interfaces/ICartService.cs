using Shopee.Service.DTOs.Carts;
using Shopee.Service.DTOs.OrderItems;

namespace Shopee.Service.Interfaces;

public interface ICartService
{
    Task<CartViewDto> CreateAsync(CartCreationDto dto);
    Task<CartViewDto> GetByIdAsync(long id);
    Task<bool> DeleteAsync(long id);
    Task<CartViewDto> DropItemAsync(long userId, long itemId);
    Task<CartViewDto> AddItemAsync(long userId, OrderItemCreationDto orderItemCreationDto);
    Task<List<CartViewDto>> GetAllAsync();
}