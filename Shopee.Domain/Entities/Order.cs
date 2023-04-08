using Shopee.Domain.Commons;

namespace Shopee.Domain.Entities; 
public class Order : Auditable
{
    public long PaymentId { get; set; }
    public long UserId { get; set; }
}
