using Shopee.Domain.Commons;

namespace Shopee.Domain.Entities;

public class Cart : Auditable
{
    public long[] OrderItemIds { get; set; }
    //public List<OrderItem> OrderItems { get; set; }

    //public IEnumerable<User> Users { get; set; }
}
