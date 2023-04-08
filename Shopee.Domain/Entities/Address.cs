using Shopee.Domain.Commons;

namespace Shopee.Domain.Entities;

public class Address : Auditable
{
    public long UserId { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string Neighborhood { get; set; }
    public int HouseNumber { get; set; }
    public int? DoorNumber { get; set; }
}
