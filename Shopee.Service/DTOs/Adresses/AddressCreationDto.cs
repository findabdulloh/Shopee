namespace Shopee.Service.DTOs.Adresses;

public class AddressCreationDto
{
    public string City { get; set; }
    public string District { get; set; }
    public string Neighborhood { get; set; }
    public int HouseNumber { get; set; }
    public int? DoorNumber { get; set; }
    public long UserId { get; set; }
}