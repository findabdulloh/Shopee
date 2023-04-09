using Shopee.Domain.Commons;
using Shopee.Service.DTOs.OrderItems;

namespace Shopee.Service.DTOs.Carts;

public class CartViewDto : Auditable
{
    public List<OrderItemViewDto> Items { get; set; }
    public decimal Amount { get; set; }
}