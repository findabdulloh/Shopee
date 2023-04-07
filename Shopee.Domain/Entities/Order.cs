using Shopee.Domain.Commons;

namespace Shopee.Domain.Entities; 
public class Order : Auditable
{
    public long PaymentId { get; set; }
    //public Payment Payment { get; set; }
    public long UserId { get; set; }
    //public User User { get; set; }

    //public IEnumerable<OrderItem> OrderItems { get; set; }
}
