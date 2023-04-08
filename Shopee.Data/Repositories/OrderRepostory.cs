using Microsoft.EntityFrameworkCore;
using Shopee.Data.DbContexts;
using Shopee.Data.IRepositories;
using Shopee.Domain.Entities;
using System.Linq.Expressions;

namespace Shopee.Data.Repositories;
public class OrderRepostory : IOrderRepostory
{
    private ShopeDbContext context = new ShopeDbContext();
    public async Task<Order> CreateAsync(Order order)
    {
        var userForInsert = await this.context.Orders.AddAsync(order);
        return userForInsert.Entity;
    }

    public async Task<bool> DeleteAsync(Expression<Func<Order, bool>> expression)
    {
        var OrderForDelete = await this.context.Orders.FirstOrDefaultAsync(expression);

        this.context.Orders.Remove(OrderForDelete);
        return true;
    }

    public async Task<List<Order>> GetAllASync(Expression<Func<Order, bool>> expression = null)
        => await this.context.Orders.ToListAsync();

    public async Task<Order> GetAsync(Expression<Func<Order, bool>> expression)
    => await this.context.Orders.FirstOrDefaultAsync(expression);

    public async Task<Order> UpdateAsync(Order order)
    {
        var orderForUpdate = await this.context.Orders.FirstOrDefaultAsync(u => u.Id == order.Id);

        orderForUpdate.Status = order.Status;
        orderForUpdate.UpdatedAt = DateTime.UtcNow;

        return orderForUpdate;
    }

    public async Task<bool> SaveChangesAsync()
             => 0 < (await context.SaveChangesAsync());

}