using Shopee.Data.IRepositories;
using Shopee.Data.Repositories;
using Shopee.Domain.Entities;
using Shopee.Domain.Enums;
using System.Numerics;
using System;
using Shopee.Data.DbContexts;
using Shopee.Service.Interfaces;
using Shopee.Service.Services;
using Shopee.Service.DTOs;

namespace Shopee;

class Program
{
    public static async Task Main(string[] args)
    {
        //IUserRepostory user = new UserRepostory();


        //var newUser = new User()
        //{
        //    Id = 7,
        //    FirstName = "da",
        //    LastName = "da",
        //    Email = "ad",
        //    UserName = "ad",
        //    Password = "ad",
        //    Phone = "ad"
        //};

        //var getUser = await user.UpdateAsync(newUser);

        //Console.WriteLine("----------------");

        //var users = await user.GetAllASync();
        //foreach (var item in users)
        //{
        //    Console.WriteLine(item.FirstName + " " + item.Id);
        //}

    }
}