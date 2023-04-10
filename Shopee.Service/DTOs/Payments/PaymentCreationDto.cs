using Shopee.Domain.Enums;

namespace Shopee.Service.DTOs.Payments;

public class PaymentCreationDto
{
    public PaymentType Type { get; set; }
    public long UserId { get; set; } 
}
