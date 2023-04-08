using Shopee.Domain.Commons;

namespace Shopee.Domain.Entities; 
public class OrderItem : Auditable
{
    public long ProductId { get; set; }
    public int Count { get; set; }
    public long? OrderId { get; set; }
}
