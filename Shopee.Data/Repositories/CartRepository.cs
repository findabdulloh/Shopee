using Microsoft.EntityFrameworkCore;
using Shopee.Data.DbContexts;
using Shopee.Data.IRepositories;
using Shopee.Domain.Entities;
using System.Linq;
using System.Linq.Expressions;
using System.Net;

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
        => expression is null ? await context.Carts.ToListAsync()
            : await this.context.Carts.Where(expression).ToListAsync();

    public async Task<Cart> GetAsync(Expression<Func<Cart, bool>> expression)
    => await this.context.Carts.FirstOrDefaultAsync(expression);

    public async Task<Cart> UpdateAsync(Cart cart)
    {
        return context.Update(cart).Entity;
    }
    public async Task<bool> SaveChangesAsync()
            => 0 < (await context.SaveChangesAsync());

}