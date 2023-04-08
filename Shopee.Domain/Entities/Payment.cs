using Shopee.Domain.Commons;
using Shopee.Domain.Enums;

namespace Shopee.Domain.Entities; 
public class Payment : Auditable
{
    public PaymentType Type { get; set; }
    public bool IsPaid { get; set; }
    public decimal Amount { get; set; }
}
