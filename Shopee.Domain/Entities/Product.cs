using Shopee.Domain.Commons;

namespace Shopee.Domain.Entities; 
public class Product : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }
    public long CategoryId { get; set; }
    public string PhotoUrl { get; set; } = "https://www.mrpanet.org/global_graphics/default-store-350x350.jpg";
    public string SearchTags { get; set; }
}
