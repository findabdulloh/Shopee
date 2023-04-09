using Shopee.Domain.Entities;
using Shopee.Service.DTOs.Messages;

namespace Shopee.Service.Interfaces;

public interface IMessageService
{
    Task<Message> CreateAsync(MessageCreationDto dto);
    Task<Message> GetByIdAsync(long id);
    Task<bool> DeleteAsync(long id);
    Task<Message> ModifyAsync(long id, string text);
    Task<List<Message>> GetAllQuestionsAsync();
    Task<List<Message>> GetAllForUserAsync(long userId);
}
