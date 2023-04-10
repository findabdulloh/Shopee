using Microsoft.EntityFrameworkCore;
using Shopee.Domain.Entities;

namespace Shopee.Data.DbContexts;

public class ShopeDbContext : DbContext
{
    public virtual DbSet<Address> Addresses { get; set; }
    public virtual DbSet<Cart> Carts { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Message> Messages { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<OrderItem> OrderItems { get; set; }
    public virtual DbSet<Payment> Payments { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost; Database=ShopeMVC; User Id=postgres; password=admin");
    }
}
