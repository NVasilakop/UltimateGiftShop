using Microsoft.EntityFrameworkCore;
using System;
using UltimateGiftShop.Repositories.DataModels;

namespace UltimateGiftShop.Repositories
{
    public class UltimateGiftShopDbContext : DbContext
    {
        public UltimateGiftShopDbContext(DbContextOptions<UltimateGiftShopDbContext> options)
           : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryDiscount> CategoryDiscounts { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }


    }
}
