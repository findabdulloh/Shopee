using Shopee.Domain.Entities;
using Shopee.Service.DTOs;
using Shopee.Service.Helpers;
using System.Linq.Expressions;

namespace Shopee.Service.Interfaces;

public interface IUserService
{
    Task<Response<UserForResultDto>> CreateAsync (UserForCreationDto user);
    Task<Response<UserForResultDto>> UpdateAsync(UserForCreationDto user, long id);
    Task<Response<bool>> DeleteAsync(Expression<Func<UserForCreationDto, bool>> expression);
    Task<Response<UserForResultDto>> GetAsync(Expression<Func<UserForCreationDto, bool>> expression);
    Task<Response<IEnumerable<UserForResultDto>>> GetAllAsync(Expression<Func<UserForCreationDto, bool>> expression = null);
}
