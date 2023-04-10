using Shopee.Domain.Commons;
using Shopee.Domain.Enums;

namespace Shopee.Domain.Entities; 
public class Order : Auditable
{
    public long PaymentId { get; set; }
    public long UserId { get; set; }
    public OrderStatus Status { get; set; }
}
