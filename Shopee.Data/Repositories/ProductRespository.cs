using Microsoft.EntityFrameworkCore;
using Shopee.Data.DbContexts;
using Shopee.Data.IRepositories;
using Shopee.Domain.Entities;
using System.Linq;
using System.Linq.Expressions;
using System.Net;

namespace Shopee.Data.Repositories;
public class ProductRepository : IProductRepository
{
    private ShopeDbContext context = new ShopeDbContext();
    public async Task<Product> CreateAsync(Product user)
    {
        var productForInsert = await this.context.Products.AddAsync(user);
        return productForInsert.Entity;
    }

    public async Task<bool> DeleteAsync(Expression<Func<Product, bool>> expression)
    {
        var ProductForDelete = await this.context.Products.FirstOrDefaultAsync(expression);

        this.context.Products.Remove(ProductForDelete);
        return true;
    }

    public async Task<List<Product>> GetAllASync(Expression<Func<Product, bool>> expression = null)
        => expression is null ? await context.Products.ToListAsync()
            : await this.context.Products.Where(expression).ToListAsync();

    public async Task<Product> GetAsync(Expression<Func<Product, bool>> expression)
        => await this.context.Products.FirstOrDefaultAsync(expression);

    public async Task<Product> UpdateAsync(Product product)
    {
        return context.Update(product).Entity;
    }
    public async Task<bool> SaveChangesAsync()
            => 0 < (await context.SaveChangesAsync());

}