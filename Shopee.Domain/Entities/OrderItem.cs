using Shopee.Domain.Commons;

namespace Shopee.Domain.Entities; 
public class OrderItem : Auditable
{
    public long ProductId { get; set; }
    //public Product Product { get; set; }
    public int Count { get; set; }
    public long? OrderId { get; set; }
    //public Order Order { get; set; }

    //public IEnumerable<Cart> Carts { get; set;}
}
