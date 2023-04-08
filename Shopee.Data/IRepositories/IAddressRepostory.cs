using Shopee.Domain.Entities;
using System.Linq.Expressions;

namespace Shopee.Data.IRepositories;

public interface IAddressRepostory
{
    Task<Address> CreateAsync(Address address);
    Task<Address> UpdateAsync(Address address);
    Task<bool> DeleteAsync(Expression<Func<Address, bool>> expression);
    Task<Address> GetAsync(Expression<Func<Address, bool>> expression);
    Task<List<Address>> GetAllASync(Expression<Func<Address, bool>> expression = null);
    Task<bool> SaveChangesAsync();
}