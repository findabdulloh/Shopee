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
        await this.context.SaveChangesAsync();
        return userForInsert.Entity;
    }

    public async Task<bool> DeleteAsync(Expression<Func<Order, bool>> expression)
    {
        var OrderForDelete = await this.context.Orders.FirstOrDefaultAsync(expression);

        this.context.Orders.Remove(OrderForDelete);
        await this.context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Order>> GetAllASync(Expression<Func<Order, bool>> expression = null)
        => await this.context.Orders.ToListAsync();

    public async Task<Order> GetAsync(Expression<Func<Order, bool>> expression)
    => await this.context.Orders.FirstOrDefaultAsync(expression);

}
