using Shopee.Service.DTOs;
using Shopee.Service.DTOs.Users;

namespace Shopee.Service.Interfaces;

public interface IUserService
{
    Task<UserViewDto> CreateAsync(UserCreationDto dto);
    Task<UserViewDto> GetByIdAsync(long id);
    Task<bool> DeleteAsync(long id);
    Task<UserViewDto> ModifyAsync(long id, UserCreationDto dto);
    Task<List<UserViewDto>> GetAllAsync();
    Task<UserViewDto> LoginAsync(string password, string username);
}
