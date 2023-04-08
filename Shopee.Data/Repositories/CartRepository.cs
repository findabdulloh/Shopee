using Microsoft.EntityFrameworkCore;
using Shopee.Data.DbContexts;
using Shopee.Data.IRepositories;
using Shopee.Domain.Entities;
using System.Linq.Expressions;

namespace Shopee.Data.Repositories;

public class CartRepository : ICartRepository
{
    private ShopeDbContext context = new ShopeDbContext();

    public async Task<Cart> CreateAsync(Cart cart)
    {
        var userForInsert = await this.context.Carts.AddAsync(cart);
        await this.context.SaveChangesAsync();
        return userForInsert.Entity;
    }

    public async Task<bool> DeleteAsync(Expression<Func<Cart, bool>> expression)
    {
        var CartForDelete = await this.context.Carts.FirstOrDefaultAsync(expression);

        this.context.Carts.Remove(CartForDelete);
        return true;
    }

    public async Task<List<Cart>> GetAllASync(Expression<Func<Cart, bool>> expression = null)
        => await this.context.Carts.ToListAsync();

    public async Task<Cart> GetAsync(Expression<Func<Cart, bool>> expression)
    => await this.context.Carts.FirstOrDefaultAsync(expression);

    public async Task<Cart> UpdateAsync(Cart cart)
    {
        var cartForUpdate = await this.context.Carts.FirstOrDefaultAsync(u => u.Id == cart.Id);

        cartForUpdate.OrderItemIds = cart.OrderItemIds;
        cartForUpdate.UpdatedAt = DateTime.UtcNow;

        return cartForUpdate;
    }
    public async Task<bool> SaveChangesAsync()
            => 0 < (await context.SaveChangesAsync());

}