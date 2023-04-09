using Shopee.Data.DbContexts;
using Shopee.Data.IRepositories;
using Shopee.Data.Repositories;
using Shopee.Domain.Entities;
using Shopee.Service.DTOs.Adresses;
using Shopee.Service.Interfaces;

namespace Shopee.Service.Services;

public class AddressService : IAddressService
{
    private IAddressRepository addressRepository = new AddressRepository();
    public async Task<Address> CreateAsync(AddressCreationDto dto)
    {
        var mappedEntity = new Address()
        {
            City = dto.City,
            District = dto.District,
            Neighborhood = dto.Neighborhood,
            HouseNumber = dto.HouseNumber,
            DoorNumber = dto.DoorNumber,
            UserId = dto.UserId
        };

        var insertedEntity = await this.addressRepository.CreateAsync(mappedEntity);

        await this.addressRepository.SaveChangesAsync();
        return insertedEntity;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entity = this.addressRepository.GetAsync(a => a.Id == id);
        if (entity is null)
            return false;

        await this.addressRepository.DeleteAsync(a => a.Id == id);
        await this.addressRepository.SaveChangesAsync();
        return true;
    }

    public async Task<List<Address>> GetAllAsync()
        => await this.addressRepository.GetAllASync();

    public Task<Address> GetByIdAsync(long id)
    {
        var entity = this.addressRepository.GetAsync(a => a.Id == id);

        if (entity is null)
            return null;

        return entity;
    }

    public async Task<Address> GetByUserIdAsync(long userId)
        => await this.addressRepository.GetAsync(a => a.UserId == userId);

    public async Task<Address> ModifyAsync(long id, AddressCreationDto dto)
    {
        var entity = await this.addressRepository.GetAsync(a => a.Id == id);

        if (entity is null)
            return null;

        entity.City = dto.City;
        entity.District = dto.District;
        entity.Neighborhood = dto.Neighborhood;
        entity.HouseNumber = dto.HouseNumber;
        entity.DoorNumber = dto.DoorNumber;
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UserId = dto.UserId;

        var updatedEntity = await this.addressRepository.UpdateAsync(entity);
        await this.addressRepository.SaveChangesAsync();
        return updatedEntity;
    }
}
