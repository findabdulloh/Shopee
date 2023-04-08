using Shopee.Domain.Commons;

namespace Shopee.Domain.Entities;

public class Address : Auditable
{
    public string City { get; set; }
    public string Distinct { get; set; }
    public string Neighborhood { get; set; }
    public int HouseNumber { get; set; }
    public int? DoorNumber { get; set; }
}
