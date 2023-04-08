using Shopee.Domain.Entities;
using Shopee.Service.DTOs.Adresses;
using Shopee.Service.Interfaces;

namespace Shopee.Service.Services
{
    public class AddressService : IAddressService
    {
        public Task<Address> CreateAsync(AddressCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Address>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetByUserIdAsync(long userId)
        {
            throw new NotImplementedException();
        }

        public Task<Address> ModifyAsync(long id, AddressCreationDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
