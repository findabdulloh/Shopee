using Shopee.Data.DbContexts;
using Shopee.Data.IRepositories;
using Shopee.Data.Repositories;
using Shopee.Domain.Entities;
using Shopee.Service.DTOs.Adresses;
using Shopee.Service.Interfaces;

namespace Shopee.Service.Services
{
    public class AddressService : IAddressService
    {
        private IGenericRepository<Address> genericRepository = new GenericRepository<Address>(new ShopeDbContext());
        public Task<Address> CreateAsync(AddressCreationDto dto)
        {
            var entity = this.genericRepository.GetAsync(a => a.HouseNumber == dto.HouseNumber);
            if (entity is not null)
                return null;
            var mappedEntity = new Address()
            {
                City = dto.City,
                District = dto.District,
                Neighborhood = dto.Neighborhood,
                HouseNumber = dto.HouseNumber,
                DoorNumber = dto.DoorNumber
            };

            var addedEntity = this.genericRepository.InsertAsync(mappedEntity);
            return addedEntity;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = this.genericRepository.GetAsync(a => a.Id == id);
            if (entity is null)
                return false;

            await this.genericRepository.DeleteAsync(a => a.Id == id);
            return true;
        }

        public async Task<List<Address>> GetAllAsync()
        {
            var entities = await this.genericRepository.GetAllAsync();
            return entities.ToList();
        }

        public Task<Address> GetByIdAsync(long id)
        {
            var entity = this.genericRepository.GetAsync(a => a.Id == id);

            if (entity is null)
                return null;

            return entity;
        }

        public Task<Address> GetByUserIdAsync(long userId)
        {
            var entity = this.genericRepository.GetAsync(a => a.UserId == userId);
            if (entity is null)
                return null;

            return entity;
        }

        public Task<Address> ModifyAsync(long id, AddressCreationDto dto)
        {
            var entity = this.genericRepository.GetAsync(a => a.Id == id);

            if (entity is null)
                return null;

            var mappedAddress = new Address()
            {
                City = dto.City,
                District = dto.District,
                Neighborhood = dto.Neighborhood,
                HouseNumber = dto.HouseNumber,
                DoorNumber = dto.DoorNumber,
                UpdatedAt = DateTime.UtcNow,
            };

            var updatedAddress = this.genericRepository.UpdateAsync(mappedAddress);
            return updatedAddress;
        }
    }
}
}
