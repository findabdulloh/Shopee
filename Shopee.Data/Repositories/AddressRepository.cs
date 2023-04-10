using Microsoft.EntityFrameworkCore;
using Shopee.Data.DbContexts;
using Shopee.Data.IRepositories;
using Shopee.Domain.Entities;
using System.Linq;
using System.Linq.Expressions;

namespace Shopee.Data.Repositories;

public class AddressRepository : IAddressRepository
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
        return context.Update(address).Entity;

    }

    public async Task<List<Address>> GetAllASync(Expression<Func<Address, bool>> expression)
        => expression is null ? await context.Addresses.ToListAsync()
            : await this.context.Addresses.Where(expression).ToListAsync();

    public async Task<bool> SaveChangesAsync()
            => 0 < (await context.SaveChangesAsync());

}