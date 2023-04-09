using Shopee.Service.DTOs.Carts;
using Shopee.Service.DTOs.OrderItems;
using Shopee.Service.Interfaces;

namespace Shopee.Service.Services;

public class CartService : ICartService
{
    public Task<CartViewDto> AddItemAsync(long userId, OrderItemCreationDto orderItemCreationDto)
    {
        throw new NotImplementedException();
    }

    public Task<CartViewDto> CreateAsync(CartCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<CartViewDto> DropItemAsync(long itemId)
    {
        throw new NotImplementedException();
    }

    public Task<List<CartViewDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CartViewDto> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
