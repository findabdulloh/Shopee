using Shopee.Domain.Commons;
using Shopee.Service.DTOs.Products;

namespace Shopee.Service.DTOs.OrderItems;

public class OrderItemViewDto : Auditable
{
    public ProductViewDto Product { get; set; }
    public int Count { get; set; }
    public decimal TotalPrice { get; set; }
}
