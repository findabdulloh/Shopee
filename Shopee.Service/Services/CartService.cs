using Shopee.Data.IRepositories;
using Shopee.Data.Repositories;
using Shopee.Domain.Entities;
using Shopee.Service.DTOs.Carts;
using Shopee.Service.DTOs.OrderItems;
using Shopee.Service.DTOs.Orders;
using Shopee.Service.Interfaces;
using System.Linq.Expressions;

namespace Shopee.Service.Services;

public class CartService : ICartService
{
    private readonly ICartRepository cartRepo = new CartRepository();
    private readonly IUserRepository userRepo = new UserRepository();
    private readonly IOrderItemService orderItemService = new OrderItemService();
    public async Task<CartViewDto> AddItemAsync(long userId, OrderItemCreationDto orderItemCreationDto)
    {
        var user = await userRepo.GetAsync(u => u.Id == userId);

        if (user is null)
            return null;

        var cart = await cartRepo.GetAsync(c => c.Id == user.CartId);

        var orderItem = await orderItemService.CreateAsync(orderItemCreationDto);

        cart.OrderItemIds.Add(orderItem.Id);
        cart.UpdatedAt = DateTime.UtcNow;

        await cartRepo.UpdateAsync(cart);
        await cartRepo.SaveChangesAsync();

        var cartItems = await orderItemService
            .GetAllAsync(o => cart.OrderItemIds.Contains(o.Id));

        var totalPrice = 0m;
        foreach (var item in cartItems)
            totalPrice += item.TotalPrice;

        return new CartViewDto
        {
            Id = cart.Id,
            CreatedAt = cart.CreatedAt,
            UpdatedAt = cart.UpdatedAt,
            Items = cartItems,
            TotalPrice = totalPrice
        };
    }

    public async Task<CartViewDto> CreateAsync(CartCreationDto dto)
    {
        var createdEntity = await cartRepo.CreateAsync(new Cart
        {
            OrderItemIds = new List<long>(),
            CreatedAt = DateTime.UtcNow
        });

        return new CartViewDto
        {
            TotalPrice = 0,
            CreatedAt = createdEntity.CreatedAt,
            UpdatedAt = null,
            Id = createdEntity.Id,
            Items = new List<OrderItemViewDto>()
        };
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entity = await cartRepo.GetAsync(c => c.Id == id);

        if (entity is null)
            return false;

        await cartRepo.DeleteAsync(o => o.Id == id);
        await this.cartRepo.SaveChangesAsync();
        return true;
    }

    public async Task<CartViewDto> DropItemAsync(long userId, long itemId)
    {
        var user = await userRepo.GetAsync(u => u.Id == userId);

        if (user is null)
            return null;

        var cart = await cartRepo.GetAsync(c => c.Id == user.CartId);

        if (!cart.OrderItemIds.Any(o => o == itemId))
            return null;

        cart.OrderItemIds.Remove(itemId);
        cart.UpdatedAt = DateTime.UtcNow;

        await cartRepo.UpdateAsync(cart);
        await orderItemService.DeleteAsync(itemId);
        await cartRepo.SaveChangesAsync();

        var cartItems = await orderItemService
            .GetAllAsync(o => cart.OrderItemIds.Contains(o.Id));

        var totalPrice = 0m;
        foreach (var item in cartItems)
            totalPrice += item.TotalPrice;

        return new CartViewDto
        {
            Id = cart.Id,
            CreatedAt = cart.CreatedAt,
            UpdatedAt = cart.UpdatedAt,
            Items = cartItems,
            TotalPrice = totalPrice
        };
    }

    public async Task<List<CartViewDto>> GetAllAsync()
    {
        var mappedDtos = new List<CartViewDto>();

        foreach (var item in await cartRepo.GetAllASync())
        {
            var cartItems = await orderItemService
                .GetAllAsync(o => item.OrderItemIds.Contains(o.Id));
            var totalPrice = 0m;
            foreach (var i in cartItems)
                totalPrice += i.TotalPrice;

            mappedDtos.Add(new CartViewDto
            {
                Id = item.Id,
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt,
                Items = cartItems,
                TotalPrice = totalPrice
            });
        }

        return mappedDtos;
    }

    public async Task<CartViewDto> GetByIdAsync(long id)
    {
        var entity = await cartRepo.GetAsync(o => o.Id == id);
        if (entity is null) return null;

        var cartItems = await orderItemService
            .GetAllAsync(o => entity.OrderItemIds.Contains(o.Id));
        var totalPrice = 0m;
        foreach (var i in cartItems)
            totalPrice += i.TotalPrice;

        return new CartViewDto
        {
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            Items = cartItems,
            TotalPrice = totalPrice
        };
    }
}
