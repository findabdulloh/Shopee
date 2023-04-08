using Microsoft.EntityFrameworkCore;
using Shopee.Data.DbContexts;
using Shopee.Data.IRepositories;
using Shopee.Domain.Entities;
using System.Linq.Expressions;

namespace Shopee.Data.Repositories;
public class CatergoryRepostory : ICategoryRepostory
{
    private ShopeDbContext context = new ShopeDbContext();
    public async Task<Category> CreateAsync(Category category)
    {
        var userForInsert = await this.context.Categories.AddAsync(category);
        await this.context.SaveChangesAsync();
        return userForInsert.Entity;
    }

    public async Task<bool> DeleteAsync(Expression<Func<Category, bool>> expression)
    {
        var CategoryForDelete = await this.context.Categories.FirstOrDefaultAsync(expression);

        this.context.Categories.Remove(CategoryForDelete);
        await this.context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Category>> GetAllASync(Expression<Func<Category, bool>> expression = null)
        => await this.context.Categories.ToListAsync();

    public async Task<Category> GetAsync(Expression<Func<Category, bool>> expression)
    => await this.context.Categories.FirstOrDefaultAsync(expression);

    public async Task<Category> UpdateAsync(Category category)
    {
        var categoryForUpdate = await this.context.Categories.FirstOrDefaultAsync(u => u.Id == category.Id);

        categoryForUpdate.Description = category.Description;
        categoryForUpdate.UpdatedAt = DateTime.UtcNow;
        categoryForUpdate.Name = category.Name;

        await this.context.SaveChangesAsync();

        return categoryForUpdate;
    }
}