using Shopee.Domain.Commons;
using Shopee.Domain.Entities;
using Shopee.Domain.Enums;

namespace Shopee.Service.DTOs.Orders;

public class OrderViewDto : Auditable
{
    public Payment Payment { get; set; }
    public OrderStatus Status { get; set; }
    public long UserId { get; set; }
    public decimal TotalPrice { get; set; }
}
