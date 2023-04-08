using Shopee.Domain.Commons;
using Shopee.Domain.Enums;

namespace Shopee.Domain.Entities;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }    
    public string UserName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public long? CartId { get; set; }
    //public Cart Cart { get; set; }
    public long? AddressId { get; set; }
    //public Address Address { get; set; }
    public Role UserRole { get; set; } = Role.Customer;

    //public IEnumerable<Message> Messages { get; set; }
    //public IEnumerable<Order> Orders { get; set; }

}
