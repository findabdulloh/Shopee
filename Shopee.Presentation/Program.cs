using Shopee.Data.IRepositories;
using Shopee.Data.Repositories;
using Shopee.Domain.Entities;
using Shopee.Domain.Enums;
using System.Numerics;
using System;
using Shopee.Data.DbContexts;

namespace Shopee;

class Program
{
    public static async Task Main(string[] args)
    {
        ShopeDbContext context = new ShopeDbContext();
        IGenericRepostory<User> user = new GenericRepostory<User>(context);
    }
}