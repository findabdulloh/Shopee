using Shopee.Data.IRepositories;
using Shopee.Data.Repositories;
using Shopee.Domain.Entities;
using Shopee.Service.DTOs.OrderItems;
using Shopee.Service.DTOs.Products;
using Shopee.Service.DTOs.Users;
using Shopee.Service.Interfaces;
using System.Linq.Expressions;

namespace Shopee.Service.Services;

public class OrderItemService : IOrderItemService
{
    private IOrderItemRepository orderItemRepo = new OrderItemRepository();
    private IProductService productService = new ProductService();
    public async Task<OrderItemViewDto> CreateAsync(OrderItemCreationDto dto)
    {
        var product = await productService.GetByIdAsync(dto.ProductId);

        if (product is null || product.Count < dto.Count)
            return null;


        var mappedEntity = new OrderItem()
        {
            Count = dto.Count,
            OrderId = dto.OrderId,
            ProductId = dto.ProductId,
            CreatedAt = DateTime.UtcNow
        };

        var addedEntity = await orderItemRepo.CreateAsync(mappedEntity);

        await this.orderItemRepo.SaveChangesAsync();


        var mappedDto = new OrderItemViewDto
        {
            Count = addedEntity.Count,
            Product = await productService.GetByIdAsync(addedEntity.ProductId),
            Id = addedEntity.Id,
            CreatedAt = addedEntity.CreatedAt,
            UpdatedAt = addedEntity.UpdatedAt
        };
        mappedDto.TotalPrice = mappedDto.Product.Price * mappedDto.Count;

        return mappedDto;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entity = await orderItemRepo.GetAsync(c => c.Id == id);

        if (entity is null)
            return false;

        await orderItemRepo.DeleteAsync(o => o.Id == id);
        await this.orderItemRepo.SaveChangesAsync();
        return true;
    }

    public async Task<List<OrderItemViewDto>> GetAllAsync(Expression<Func<OrderItem, bool>> expression)
    {
        var mappedDtos = new List<OrderItemViewDto>();

        foreach (var item in await orderItemRepo.GetAllASync(expression))
        {
            var productDto = await productService.GetByIdAsync(item.ProductId);

            mappedDtos.Add(new OrderItemViewDto
            {
                Count = item.Count,
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt,
                Id = item.Id,
                TotalPrice = productDto.Price * productDto.Count,
                Product = productDto
            });
        }

        return mappedDtos;
    }

    public async Task<OrderItemViewDto> GetByIdAsync(long id)
    {
        var entity = await orderItemRepo.GetAsync(o => o.Id == id);
        if (entity is null) return null;

        var productDto = await productService.GetByIdAsync(entity.ProductId);
        return new OrderItemViewDto
        {
            Count = entity.Count,
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            TotalPrice = productDto.Price * entity.Count,
            Product = productDto
        };
    }

    public async Task<OrderItemViewDto> ModifyCountAsync(long id, int newCount)
    {
        var entity = await this.orderItemRepo.GetAsync(u => u.Id == id);
        if (entity is null) return null;

        entity.Count = newCount;
        entity.UpdatedAt = DateTime.Now;

        await this.orderItemRepo.UpdateAsync(entity);

        await this.orderItemRepo.SaveChangesAsync();

        var productDto = await productService.GetByIdAsync(entity.ProductId);
        return new OrderItemViewDto
        {
            Count = entity.Count,
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            TotalPrice = productDto.Price * entity.Count,
            Product = productDto
        };
    }
}
