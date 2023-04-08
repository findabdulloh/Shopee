using Shopee.Domain.Entities;
using System.Linq.Expressions;

namespace Shopee.Data.IRepositories;

public interface IUserRepository
{
    Task<User> CreateAsync(User user);
    Task<User> UpdateAsync(User user);
    Task<bool> DeleteAsync(Expression<Func<User, bool>> expression);
    Task<User> GetAsync(Expression<Func<User, bool>> expression);
    Task<List<User>> GetAllASync(Expression<Func<User, bool>> expression = null);
    Task<bool> SaveChangesAsync();

}