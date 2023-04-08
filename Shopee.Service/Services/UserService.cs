using Shopee.Data.IRepositories;
using Shopee.Domain.Entities;
using Shopee.Domain.Enums;
using Shopee.Service.DTOs;
using Shopee.Service.DTOs.Users;
using Shopee.Service.Interfaces;

namespace Shopee.Service.Services;

public class UserService : IUserService
{
    IUserRepository repostory;

    public UserService(IUserRepository repostory)
    {
        this.repostory = repostory;
    }

    public async Task<UserViewDto> CreateAsync(UserCreationDto dto)
    {
        var userExist = await this.repostory.GetAllASync(u=>u.UserName == dto.UserName || u.Email == dto.Email);
        
        if(userExist is not null)
            return null;

        var mappedUser = new User()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            UserName = dto.UserName,
            Password = dto.Password,
            Phone = dto.Phone,
            UserRole = UserRole.Customer
        };

        await this.repostory.CreateAsync(mappedUser);

        var userForResult = new UserViewDto()
        {
            Id = mappedUser.Id,
            FirstName = mappedUser.FirstName,
            LastName = mappedUser.LastName,
            Email = mappedUser.Email,
            UserName = mappedUser.UserName,
            Phone = mappedUser.Phone,
            Role = mappedUser.UserRole,
            CreatedAt = mappedUser.CreatedAt,
            UpdatedAt = mappedUser.UpdatedAt,
        };

        await this.repostory.SaveChangesAsync();
        return userForResult;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var userExist = await this.repostory.GetAllASync(u => u.Id == id);
        if(userExist is null) 
            return false;
        
        await this.repostory.DeleteAsync(u=> u.Id == id);
        await this.repostory.SaveChangesAsync();
        return true;
    }

    public async Task<List<UserViewDto>> GetAllAsync()
    {
        var users = await this.repostory.GetAllASync();
        List<UserViewDto> result = new List<UserViewDto>();
        foreach (var user in users)
        {
            var userForResult = new UserViewDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                Phone = user.Phone,
                Role = user.UserRole,
            };
            result.Add(userForResult);
        }
        
        return result;
    }

    public async Task<UserViewDto> GetByIdAsync(long id)
    {
        var user = await this.repostory.GetAsync(u => u.Id == id);
        if(user is null)
            return null;
        
        var userForResult = new UserViewDto()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            UserName = user.UserName,
            Phone = user.Phone,
            Role = user.UserRole,
        };
        return userForResult;
    }

    public async Task<UserViewDto> LoginAsync(string password, string username)
    {
        var checkUser = await this.repostory
            .GetAsync(u => u.Password == password && u.UserName == username);
        
        if(checkUser is null)
            return null;


        var userForResult = new UserViewDto()
        {
            Id = checkUser.Id,
            FirstName = checkUser.FirstName,
            LastName = checkUser.LastName,
            Email = checkUser.Email,
            UserName = checkUser.UserName,
            Phone = checkUser.Phone,
            Role = checkUser.UserRole,
            CreatedAt = checkUser.CreatedAt,
            UpdatedAt = checkUser.UpdatedAt
        };
        return userForResult;
    }

    public async Task<UserViewDto> ModifyAsync(long id, UserCreationDto dto)
    {
        var userForUpdate = await this.repostory.GetAsync(u => u.Id.Equals(id));
        if(userForUpdate is null) return null;

        userForUpdate.Phone = dto.Phone;
        userForUpdate.Email = dto.Email;
        userForUpdate.FirstName = dto.FirstName;
        userForUpdate.LastName = dto.LastName;
        userForUpdate.Password = dto.Password;
        userForUpdate.UserName = dto.UserName;

        await this.repostory.UpdateAsync(userForUpdate);

        var userForResult = new UserViewDto()
        {
            Id = userForUpdate.Id,
            FirstName = userForUpdate.FirstName,
            LastName = userForUpdate.LastName,
            Email = userForUpdate.Email,
            UserName = userForUpdate.UserName,
            Phone = userForUpdate.Phone,
            Role = userForUpdate.UserRole,
        };

        await this.repostory.SaveChangesAsync();
        return userForResult;

    }
}