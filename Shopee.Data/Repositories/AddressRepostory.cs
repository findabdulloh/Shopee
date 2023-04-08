using Microsoft.EntityFrameworkCore;
using Shopee.Data.DbContexts;
using Shopee.Data.IRepositories;
using Shopee.Domain.Entities;
using System.Linq.Expressions;

namespace Shopee.Data.Repositories;

public class AddressRepostory : IAddressRepostory
{
    private ShopeDbContext context = new ShopeDbContext();

    public async Task<Address> CreateAsync(Address address)
    {
        var userForInsert = await this.context.Addresses.AddAsync(address);
        return userForInsert.Entity;
    }

    public async Task<bool> DeleteAsync(Expression<Func<Address, bool>> expression)
    {
        var AddressForDelete = await this.context.Addresses.FirstOrDefaultAsync(expression);

        this.context.Addresses.Remove(AddressForDelete);
        return true;
    }

    public async Task<Address> GetAsync(Expression<Func<Address, bool>> expression)
        => await this.context.Addresses.FirstOrDefaultAsync(expression);

    public async Task<Address> UpdateAsync(Address address)
    {
        var addressForUpdate = await this.context.Addresses.FirstOrDefaultAsync(u => u.Id == address.Id);
        this.context.Addresses.Update(addressForUpdate);
        addressForUpdate.UpdatedAt = DateTime.UtcNow;

        return addressForUpdate;
    }

    public async Task<List<Address>> GetAllASync(Expression<Func<Address, bool>> expression)
        => await this.context.Addresses.ToListAsync();

    public async Task<bool> SaveChangesAsync()
            => 0 < (await context.SaveChangesAsync());

}