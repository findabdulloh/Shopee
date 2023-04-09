using Shopee.Data.IRepositories;
using Shopee.Data.Repositories;
using Shopee.Domain.Entities;
using Shopee.Domain.Enums;
using Shopee.Service.DTOs.Messages;
using Shopee.Service.Interfaces;

namespace Shopee.Service.Services;

public class MessageService : IMessageService
{
    private readonly IMessageRepository messageRepo = new MessageRepository();
    public async Task<Message> CreateAsync(MessageCreationDto dto)
    {
        if (dto.Type == MessageType.Answer && dto.RepliedMessageId is not null)
        {
            var repliedMessage = await messageRepo.GetAsync(m => m.Id == dto.RepliedMessageId);
            if (repliedMessage is not null)
            {
                repliedMessage.Type = MessageType.AnsweredQuestion;
                await messageRepo.UpdateAsync(repliedMessage);
            }
        }

        var addedModel = await messageRepo.CreateAsync(new Message()
        {
            Text = dto.Text,
            Type = dto.Type,
            UserId = dto.UserId
        });

        await this.messageRepo.SaveChangesAsync();
        return addedModel;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entity = await messageRepo.GetAsync(c => c.Id == id);

        if (entity is null)
            return false;

        await messageRepo.DeleteAsync(c => c.Id == id);
        await this.messageRepo.SaveChangesAsync();
        return true;
    }

    public async Task<List<Message>> GetAllForUserAsync(long userId)
        => await messageRepo.GetAllASync(m => m.UserId == userId);

    public async Task<List<Message>> GetAllQuestionsAsync()
        => await messageRepo.GetAllASync(m => m.Type == MessageType.Question);

    public async Task<Message> GetByIdAsync(long id)
        => await messageRepo.GetAsync(m => m.Id == id);

    public async Task<Message> ModifyAsync(long id, string text)
    {
        var entity = await messageRepo.GetAsync(c => c.Id == id);
        if (entity is null)
            return null;

        entity.Text = text;
        entity.UpdatedAt = DateTime.UtcNow;

        var updatedEntity = await messageRepo.UpdateAsync(entity);
        await this.messageRepo.SaveChangesAsync();
        return updatedEntity;
    }
}
