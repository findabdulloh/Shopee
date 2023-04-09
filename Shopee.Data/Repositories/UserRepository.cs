using Microsoft.EntityFrameworkCore;
using Shopee.Data.DbContexts;
using Shopee.Data.IRepositories;
using Shopee.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Net;

namespace Shopee.Data.Repositories;
public class UserRepository : IUserRepository
{
    private ShopeDbContext context = new ShopeDbContext();
    public async Task<User> CreateAsync(User user)
    {
        var userForInsert = await this.context.Users.AddAsync(user);
        return userForInsert.Entity;
    }

    public async Task<bool> DeleteAsync(Expression<Func<User, bool>> expression)
    {
        var ProductForDelete = await this.context.Users.FirstOrDefaultAsync(expression);

        this.context.Users.Remove(ProductForDelete);
        return true;
    }

    public async Task<List<User>> GetAllASync(Expression<Func<User, bool>> expression = null)
        => await this.context.Users.ToListAsync();

    public async Task<User> GetAsync(Expression<Func<User, bool>> expression)
        => await this.context.Users.FirstOrDefaultAsync(expression);

    public async Task<User> UpdateAsync(User user)
    {
        return context.Update(user).Entity;
    }
    public async Task<bool> SaveChangesAsync()
            => 0 < (await context.SaveChangesAsync());

}