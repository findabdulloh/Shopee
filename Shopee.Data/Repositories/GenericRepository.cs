using Microsoft.EntityFrameworkCore;
using Shopee.Data.DbContexts;
using Shopee.Data.IRepositories;
using Shopee.Domain.Commons;
using System.Linq.Expressions;

namespace Shopee.Data.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : Auditable
{
    private readonly ShopeDbContext dbContext;
    private readonly DbSet<T> dbSet;

    public GenericRepository(ShopeDbContext dbContext)
    {
        this.dbContext = dbContext;
        this.dbSet = dbContext.Set<T>();
    }

    public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
    {
        var entitiesToDelete = await this.dbSet.Where(expression).ToListAsync();

        if(entitiesToDelete is null)
            return false;

        this.dbSet.RemoveRange(entitiesToDelete);
        return true;
    }

    public async Task<IQueryable<T>> GetAllAsync()
        => this.dbSet;


    public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        => await this.dbSet.FirstOrDefaultAsync(expression);

    public async Task<T> InsertAsync(T entity)
        => (await this.dbSet.AddAsync(entity)).Entity;


    public async Task<T> UpdateAsync(T entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        this.dbSet.Update(entity);
        return entity;
    }

    public async Task<bool> SaveChangesAsync()
        => 0 < (await dbContext.SaveChangesAsync());
}