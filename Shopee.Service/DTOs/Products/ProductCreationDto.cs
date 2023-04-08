namespace Shopee.Service.DTOs.Products;

public class ProductCreationDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }
    public long CategoryId { get; set; }
    public List<string> SearchTags { get; set; }
}
