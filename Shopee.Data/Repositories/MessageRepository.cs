using Microsoft.EntityFrameworkCore;
using Shopee.Data.DbContexts;
using Shopee.Data.IRepositories;
using Shopee.Domain.Entities;
using System.Linq;
using System.Linq.Expressions;
using System.Net;

namespace Shopee.Data.Repositories;
public class MessageRepository : IMessageRepository
{
    private ShopeDbContext context = new ShopeDbContext();
    public async Task<Message> CreateAsync(Message message)
    {
        var userForInsert = await this.context.Messages.AddAsync(message);
        return userForInsert.Entity;
    }

    public async Task<bool> DeleteAsync(Expression<Func<Message, bool>> expression)
    {
        var MessageForDelete = await this.context.Messages.FirstOrDefaultAsync(expression);

        this.context.Messages.Remove(MessageForDelete);
        return true;
    }

    public async Task<List<Message>> GetAllASync(Expression<Func<Message, bool>> expression = null)
        => expression is null ? await context.Messages.ToListAsync()
            : await this.context.Messages.Where(expression).ToListAsync();

    public async Task<Message> GetAsync(Expression<Func<Message, bool>> expression)
    => await this.context.Messages.FirstOrDefaultAsync(expression);

    public async Task<Message> UpdateAsync(Message message)
    {
        return context.Update(message).Entity;
    }

    public async Task<bool> SaveChangesAsync()
            => 0 < (await context.SaveChangesAsync());

}