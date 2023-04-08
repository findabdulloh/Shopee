using Shopee.Service.DTOs.OrderItems;

namespace Shopee.Service.DTOs.Carts;

public class CartCreationDto
{
    public List<OrderItemCreationDto> OrderItems { get; set; }
    public long UserId { get; set; }
}
