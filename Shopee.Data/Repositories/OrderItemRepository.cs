using Microsoft.EntityFrameworkCore;
using Shopee.Data.DbContexts;
using Shopee.Data.IRepositories;
using Shopee.Domain.Entities;
using System.Linq;
using System.Linq.Expressions;
using System.Net;

namespace Shopee.Data.Repositories;
public class OrderItemRepository : IOrderItemRepository
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
        => expression is null ? await context.OrderItems.ToListAsync()
            : await this.context.OrderItems.Where(expression).ToListAsync();

    public async Task<OrderItem> GetAsync(Expression<Func<OrderItem, bool>> expression)
    => await this.context.OrderItems.FirstOrDefaultAsync(expression);

    public async Task<OrderItem> UpdateAsync(OrderItem orderItem)
    {
        return context.Update(orderItem).Entity;
    }
    public async Task<bool> SaveChangesAsync()
            => 0 < (await context.SaveChangesAsync());

}