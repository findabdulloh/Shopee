using Shopee.Domain.Commons;
using Shopee.Domain.Enums;

namespace Shopee.Domain.Entities; 
public class Message : Auditable
{
    public string Text { get; set; }
    public long UserId { get; set; }
    //public User User { get; set; }
    public MessageType MessageType { get; set; }
}
