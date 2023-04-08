using Shopee.Domain.Entities;
using System.Linq.Expressions;

namespace Shopee.Data.IRepositories;

public interface IMessageRepostory
{
    Task<Message> CreateAsync(Message message);
    Task<Message> UpdateAsync(Message message);
    Task<bool> DeleteAsync(Expression<Func<Message, bool>> expression);
    Task<Message> GetAsync(Expression<Func<Message, bool>> expression);
    Task<List<Message>> GetAllASync(Expression<Func<Message, bool>> expression = null);
}