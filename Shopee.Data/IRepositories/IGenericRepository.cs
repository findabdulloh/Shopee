using Shopee.Domain.Commons;
using Shopee.Domain.Entities;
using System.Linq.Expressions;

namespace Shopee.Data.IRepositories;

public interface IGenericRepository<T> where T : Auditable
{
    Task<T> InsertAsync (T entity);
    Task<T> UpdateAsync (T entity);
    Task<bool> DeleteAsync (Expression<Func<T, bool>> expression);
    Task<T> GetAsync(Expression<Func<T, bool>> expression);
    Task<IQueryable<T>> GetAllAsync ();
    Task<bool> SaveChangesAsync();
}
