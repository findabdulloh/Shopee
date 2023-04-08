using Shopee.Service.DTOs.Payments;

namespace Shopee.Service.DTOs.Orders;

public class OrderCreationDto
{
    public long UserId { get; set; }
    public PaymentCreationDto Payment { get; set; }
}