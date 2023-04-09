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
using Shopee.Service.DTOs.Products;
using Shopee.Service.DTOs.Categories;

namespace Shopee;

class Program
{
    public static async Task Main(string[] args)
    {
        //ShopeDbContext context = new ShopeDbContext();
        //IGenericRepository<User> user = new GenericRepository<User>(context);
        IUserRepository repo = new UserRepository();
        IUserService user = new UserService(repo);



        //var users = new List<UserCreationDto>()
        //{
        //    new UserCreationDto()
        //    {
        //        FirstName = "Kamronbek",
        //        LastName = "Sulaymonov",
        //        Email = "komrondeveloper@gmail.com",
        //        UserName = "komrondeveloper",
        //        Password = "komronbek26",
        //        Phone = "+998978743353",
        //    },
        //    new UserCreationDto()
        //    {
        //        FirstName = "John",
        //        LastName = "Doe",
        //        Email = "johndoe@gmail.com",
        //        UserName = "johndoe",
        //        Password = "password123",
        //        Phone = "+1 (555) 555-5555"
        //    },
        //    new UserCreationDto()
        //    {
        //        FirstName = "Jane",
        //        LastName = "Doe",
        //        Email = "janedoe@gmail.com",
        //        UserName = "janedoe",
        //        Password = "password456",
        //        Phone = "+1 (555) 555-5556"
        //    },
        //    new UserCreationDto()
        //    {
        //        FirstName = "Bob",
        //        LastName = "Smith",
        //        Email = "bobsmith@gmail.com",
        //        UserName = "bobsmith",
        //        Password = "password789",
        //        Phone = "+1 (555) 555-5557"
        //    },
        //};



        //await user.DeleteAsync(1);
        //await user.DeleteAsync(2);
        //await user.DeleteAsync(3);
        //await user.DeleteAsync(4);

        //foreach (var item in users)
        //{
        //    await user.CreateAsync(item);
        //}

        IProductRepository product = new ProductRepository();
        IProductService product1 = new ProductService();
        
        //var products = new List<ProductCreationDto>
        //{
        //    new ProductCreationDto
        //    {
        //        Name = "iPhone 13 Pro",
        //        Count = 100,
        //        Description = "The latest iPhone with a stunning Pro camera system",
        //        Price = 129999,
        //        CategoryId = 1,
        //        SearchTags = "iPhone, Apple, smartphone, Pro, camera",
        //        PhotoUrl = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/refurb-iphone-13-pro-graphite-2023?wid=1144&hei=1144&fmt=jpeg&qlt=90&.v=1679072987081"
        //    },
        //    new ProductCreationDto
        //    {
        //        Name = "Samsung Galaxy S21 Ultra",
        //        Count = 50,
        //        Description = "The ultimate Samsung smartphone with a 108MP camera",
        //        Price = 119999,
        //        CategoryId = 1,
        //        SearchTags = "Samsung, Galaxy, smartphone, Ultra, camera",
        //        PhotoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRiYnICZr80_ZBNIfgn3DX0Iaom2L2LWfeJaA&usqp=CAU"
        //    },
        //    new ProductCreationDto
        //    {
        //        Name = "Sony WH-1000XM4",
        //        Count = 200,
        //        Description = "Premium noise-canceling headphones with excellent sound quality",
        //        Price = 34999,
        //        CategoryId = 2,
        //        SearchTags = "Sony, headphones, noise-canceling, premium, sound quality",
        //        PhotoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRRHWhxJCkPwM23_BLtViRjmtyDCgWgHUhDoQ&usqp=CAU"
        //    },
        //    new ProductCreationDto
        //    {
        //        Name = "Nintendo Switch",
        //        Count = 75,
        //        Description = "A hybrid gaming console that you can play anywhere",
        //        Price = 29999,
        //        CategoryId = 3,
        //        SearchTags = "Nintendo, Switch, gaming, hybrid, portable",
        //        PhotoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT-mS1usJZBEFyp8XJgNGFh4S_aqJ9BHyxLug&usqp=CAU"
        //    },
        //    new ProductCreationDto
        //    {
        //        Name = "Fitbit Charge 5",
        //        Count = 150,
        //        Description = "A sleek fitness tracker with advanced health and wellness features",
        //        Price = 17999,
        //        CategoryId = 5,
        //        SearchTags = "Fitbit, Charge, fitness tracker, health, wellness",
        //        PhotoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQUD0oYOODuR9099GZTHmzpX3h8FYRkbAqqNA&usqp=CAU"
        //    },
        //    new ProductCreationDto
        //    {
        //        Name = "Baliqcha)",
        //        Count = 3,
        //        CategoryId = 6,
        //        Description = "Juda ham mezzali",
        //        Price = 12345123456234567,
        //        SearchTags = "Baliqcha Fish Eat",
        //        PhotoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTxfHi_vSHFnPf1pZiupOSITRxUK6D_jVMX5g&usqp=CAU"
        //    }
        //};

        //foreach (var item in products)
        //{
        //    await product1.CreateAsync(item);
        //}

        //ICategoryService category = new CategoryService();
        //var products = new List<CategoryCreationDto>()
        //{
        //    new CategoryCreationDto()
        //    {
        //        Name = "Fruits",
        //        Description = "Fruits and organic category"
        //    },
        //    new CategoryCreationDto()
        //    {
        //        Name = "Vegetables",
        //        Description = "Vegetables and organic category"
        //    },
        //    new CategoryCreationDto()
        //    {
        //        Name = "Dairy",
        //        Description = "Dairy and organic category"
        //    },
        //    new CategoryCreationDto()
        //    {
        //        Name = "Meat",
        //        Description = "Meat and organic category"
        //    },
        //    new CategoryCreationDto()
        //    {
        //        Name = "Grains",
        //        Description = "Grains and organic category"
        //    }
        //};


        //var userss = await user.GetAllAsync();
        //foreach (var item in userss)
        //{
        //    Console.WriteLine(item.FirstName + " " + item.Role);
        //}
    }
}