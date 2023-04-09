using Shopee.Domain.Commons;
using Shopee.Domain.Entities;
using Shopee.Domain.Enums;
using Shopee.Service.DTOs.OrderItems;

namespace Shopee.Service.DTOs.Orders;

public class OrderViewDto : Auditable
{
    public Payment Payment { get; set; }
    public OrderStatus Status { get; set; }
    public long UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public List<OrderItemViewDto> Items { get; set; }
}
