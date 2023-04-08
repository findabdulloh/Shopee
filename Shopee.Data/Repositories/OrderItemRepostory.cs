using Microsoft.EntityFrameworkCore;
using Shopee.Data.DbContexts;
using Shopee.Data.IRepositories;
using Shopee.Domain.Entities;
using System.Linq.Expressions;

namespace Shopee.Data.Repositories;
public class OrderItemRepostory : IOrderItemRepostory
{
    private ShopeDbContext context = new ShopeDbContext();
    public async Task<OrderItem> CreateAsync(OrderItem orderItem)
    {
        var userForInsert = await this.context.OrderItems.AddAsync(orderItem);
        return userForInsert.Entity;
    }

    public async Task<bool> DeleteAsync(Expression<Func<OrderItem, bool>> expression)
    {
        var OrderItemForDelete = await this.context.OrderItems.FirstOrDefaultAsync(expression);

        this.context.OrderItems.Remove(OrderItemForDelete);
        return true;
    }

    public async Task<List<OrderItem>> GetAllASync(Expression<Func<OrderItem, bool>> expression = null)
        => await this.context.OrderItems.ToListAsync();

    public async Task<OrderItem> GetAsync(Expression<Func<OrderItem, bool>> expression)
    => await this.context.OrderItems.FirstOrDefaultAsync(expression);

    public async Task<OrderItem> UpdateAsync(OrderItem orderItem)
    {
        var orderItemsForUpdate = await this.context.OrderItems.FirstOrDefaultAsync(u => u.Id == orderItem.Id);

        orderItemsForUpdate.Count = orderItem.Count;
        orderItemsForUpdate.UpdatedAt = DateTime.UtcNow;

        return orderItemsForUpdate;
    }
    public async Task<bool> SaveChangesAsync()
            => 0 < (await context.SaveChangesAsync());

}