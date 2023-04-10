namespace Shopee.Service.DTOs.OrderItems;

public class OrderItemCreationDto
{
    public long ProductId { get; set; }
    public int Count { get; set; }
    public long? OrderId { get; set; }
}
