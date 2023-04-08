using Microsoft.EntityFrameworkCore;
using Shopee.Data.DbContexts;
using Shopee.Data.IRepositories;
using Shopee.Domain.Entities;
using System.Linq.Expressions;

namespace Shopee.Data.Repositories;
public class ProductRepostory : IProductRepostory
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
        => await this.context.Products.ToListAsync();

    public async Task<Product> GetAsync(Expression<Func<Product, bool>> expression)
        => await this.context.Products.FirstOrDefaultAsync(expression);

    public async Task<Product> UpdateAsync(Product product)
    {
        var productForUpdate = await this.context.Products.FirstOrDefaultAsync(u => u.Id == product.Id);

        productForUpdate.Price = product.Price;
        productForUpdate.Name = product.Name;
        productForUpdate.Description = product.Description;
        productForUpdate.Count = product.Count;
        productForUpdate.UpdatedAt = DateTime.UtcNow;

        return productForUpdate;
    }
    public async Task<bool> SaveChangesAsync()
            => 0 < (await context.SaveChangesAsync());

}