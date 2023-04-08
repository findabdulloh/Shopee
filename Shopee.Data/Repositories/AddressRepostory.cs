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
        await this.context.SaveChangesAsync();
        return userForInsert.Entity;
    }

    public async Task<bool> DeleteAsync(Expression<Func<Address, bool>> expression)
    {
        var AddressForDelete = await this.context.Addresses.FirstOrDefaultAsync(expression);

        this.context.Addresses.Remove(AddressForDelete);
        await this.context.SaveChangesAsync();
        return true;
    }

    public async Task<Address> GetAsync(Expression<Func<Address, bool>> expression)
        => await this.context.Addresses.FirstOrDefaultAsync(expression);

    public async Task<Address> UpdateAsync(Address address)
    {
        var addressForUpdate = await this.context.Addresses.FirstOrDefaultAsync(u => u.Id == address.Id);

        addressForUpdate.HouseNumber = address.HouseNumber;
        addressForUpdate.DoorNumber = address.DoorNumber;
        addressForUpdate.UpdatedAt = DateTime.UtcNow;
        addressForUpdate.City = address.City;
        addressForUpdate.District = address.District;
        addressForUpdate.Neighborhood = address.Neighborhood;

        await this.context.SaveChangesAsync();

        return addressForUpdate;
    }

    public async Task<List<Address>> GetAllASync(Expression<Func<Address, bool>> expression)
        => await this.context.Addresses.ToListAsync();
}