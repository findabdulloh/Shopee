using Shopee.Data.IRepositories;
using Shopee.Data.Repositories;
using Shopee.Domain.Entities;
using Shopee.Domain.Enums;
using System.Numerics;
using System;
using Shopee.Data.DbContexts;
using Shopee.Service.Interfaces;
using Shopee.Service.Services;
using System.Runtime.CompilerServices;
using Shopee.Service.DTOs;
using Shopee.Service.DTOs.Carts;
using Shopee.Service.DTOs.Products;

namespace Shopee;

class Program
{
    public static async Task Main(string[] args)
    {
        //ShopeDbContext context = new ShopeDbContext();
        //IGenericRepository<User> user = new GenericRepository<User>(context);
        IUserService user = new UserService();
        ICartService cart = new CartService();
        IProductService productSer = new ProductService();

        var users = new List<UserCreationDto>()
        {
            new UserCreationDto()
            {
                FirstName = "Kamronbek",
                LastName = "Sulaymonov",
                Email = "komrondeveloper@gmail.com",
                UserName = "komrondeveloper",
                Password = "komronbek26",
                Phone = "+998978743353",
            },
            new UserCreationDto()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@gmail.com",
                UserName = "johndoe",
                Password = "password123",
                Phone = "+1 (555) 555-5555"
            },
            new UserCreationDto()
            {
                FirstName = "Jane",
                LastName = "Doe",
                Email = "janedoe@gmail.com",
                UserName = "janedoe",
                Password = "password456",
                Phone = "+1 (555) 555-5556"
            },
            new UserCreationDto()
            {
                FirstName = "Bob",
                LastName = "Smith",
                Email = "bobsmith@gmail.com",
                UserName = "bobsmith",
                Password = "password789",
                Phone = "+1 (555) 555-5557"
            },
        };

        //foreach (var item in users)
        //{
        //    await user.CreateAsync(item);
        //}

        var product = await productSer.CreateAsync(new ProductCreationDto
        {
            SearchTags = " ",
            Count = 8271,
            Name = "Some",
            Description = "asd",
            Price = 19999,
        });

        var newCart = await cart.GetByUserIdAsync(1);

        Console.WriteLine(product?.Name);
        Console.WriteLine(newCart?.TotalPrice);
        var userss = await user.GetAllAsync();
        foreach (var item in userss)
        {
            Console.WriteLine(item.FirstName + " " + item.Role);
        }
    }
}