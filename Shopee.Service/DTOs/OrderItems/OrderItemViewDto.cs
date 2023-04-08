using Shopee.Service.DTOs.Products;

namespace Shopee.Service.DTOs.OrderItems;

public class OrderItemViewDto
{
    public ProductViewDto Product { get; set; }
    public int Count { get; set; }
    public decimal Amount { get; set; }
}
