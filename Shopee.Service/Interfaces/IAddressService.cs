using Shopee.Domain.Entities;
using Shopee.Service.DTOs.Adresses;

namespace Shopee.Service.Interfaces;

public interface IAddressService
{
    Task<Address> CreateAsync(AddressCreationDto dto);
    Task<Address> GetByUserIdAsync(long userId);
    Task<Address> GetByIdAsync(long id);
    Task<bool> DeleteAsync(long id);
    Task<Address> ModifyAsync(long id, AddressCreationDto dto);
    Task<List<Address>> GetAllAsync();
}
