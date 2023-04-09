using Shopee.Domain.Commons;

namespace Shopee.Service.DTOs.Products;

public class ProductViewDto : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }
    public string CategoryName { get; set; }
    public string SearchTags { get; set; }
    public string PhotoUrl { get; set; }
}
