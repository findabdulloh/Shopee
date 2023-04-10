namespace Shopee.Domain.Enums;

public enum OrderStatus : byte
{
    Pending,
    Accepted,
    InProgress,
    Ready,
    Delivering,
    Done,
    Cancelled
}
