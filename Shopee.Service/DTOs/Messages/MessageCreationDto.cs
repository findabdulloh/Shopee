using Shopee.Domain.Enums;

namespace Shopee.Service.DTOs.Messages;

public class MessageCreationDto
{
    public long? RepliedMessageId { get; set; }
    public string Text { get; set; }
    public long UserId { get; set; }
    public MessageType Type { get; set; }
}
