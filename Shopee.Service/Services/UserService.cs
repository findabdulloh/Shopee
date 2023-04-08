using AutoMapper;
using Shopee.Data.DbContexts;
using Shopee.Data.IRepositories;
using Shopee.Data.Repositories;
using Shopee.Domain.Entities;
using Shopee.Service.DTOs;
using Shopee.Service.Helpers;
using Shopee.Service.Interfaces;
using System.Linq.Expressions;

namespace Shopee.Service.Services;

public class UserService : IUserService
{
    public Task<Response<UserForResultDto>> CreateAsync(UserForCreationDto user)
    {
        throw new NotImplementedException();
    }

    public Task<Response<bool>> DeleteAsync(Expression<Func<UserForCreationDto, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<Response<IEnumerable<UserForResultDto>>> GetAllAsync(Expression<Func<UserForCreationDto, bool>> expression = null)
    {
        throw new NotImplementedException();
    }

    public Task<Response<UserForResultDto>> GetAsync(Expression<Func<UserForCreationDto, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<Response<UserForResultDto>> UpdateAsync(UserForCreationDto user, long id)
    {
        throw new NotImplementedException();
    }
}
