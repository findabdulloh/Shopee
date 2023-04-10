using Shopee.Domain.Commons;
using Shopee.Domain.Enums;

namespace Shopee.Service.DTOs.Users;

public class UserViewDto : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string ProfilePhotoUrl { get; set; } = "https://i.stack.imgur.com/34AD2.jpg";
    public UserRole Role { get; set; }
}
