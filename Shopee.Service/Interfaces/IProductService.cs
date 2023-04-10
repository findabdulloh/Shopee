using Shopee.Service.DTOs.Payments;
using Shopee.Service.DTOs.Products;

namespace Shopee.Service.Interfaces;

public interface IProductService
{
    Task<ProductViewDto> CreateAsync(ProductCreationDto dto);
    Task<ProductViewDto> GetByIdAsync(long id);
    Task<bool> DeleteAsync(long id);
    Task<ProductViewDto> ModifyAsync(long id, ProductCreationDto dto);
    Task<List<ProductViewDto>> GetAllAsync();
}