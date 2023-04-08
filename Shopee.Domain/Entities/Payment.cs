using Shopee.Domain.Commons;
using Shopee.Domain.Enums;

namespace Shopee.Domain.Entities; 
public class Payment : Auditable
{
    public PaymentType PaymentType { get; set; }
    public bool IsPaid { get; set; }

    //public IEnumerable<Order> Orders { get; set; }
}
