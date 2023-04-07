using Shopee.Domain.Commons;

namespace Shopee.Domain.Entities; 
public class Category : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }

    //public IEnumerable<Product> Products { get; set; }

}
