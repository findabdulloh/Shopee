using Microsoft.EntityFrameworkCore;
using Shopee.Data.DbContexts;
using Shopee.Data.IRepositories;
using Shopee.Domain.Commons;
using System.Linq.Expressions;

namespace Shopee.Data.Repositories;

public class GenericRepostory<T> : IGenericRepostory<T> where T : Auditable
{
    private readonly ShopeDbContext context;
    private readonly DbSet<T> dbSet;

    public GenericRepostory(ShopeDbContext context)
    {
        this.context = context;
        this.dbSet = context.Set<T>();
    }

    public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
    {
        var entitiesToDelete = await this.dbSet.Where(expression).ToListAsync();

        if(entitiesToDelete is null)
            return false;

        this.dbSet.RemoveRange(entitiesToDelete);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
        => await this.dbSet.ToListAsync();


    public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        => await this.dbSet.FirstOrDefaultAsync(expression);

    public async Task<T> InsertAsync(T entity)
    {
        var entityForInsert = await this.dbSet.AddAsync(entity);
        await context.SaveChangesAsync();
        return entityForInsert.Entity;
    }


    public async Task<T> UpdateAsync(T entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        this.dbSet.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }
}
