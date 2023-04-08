using Shopee.Domain.Commons;

namespace Shopee.Service.DTOs;

public class UserForResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public long? CartId { get; set; }
    public long? AddressId { get; set; }
}
