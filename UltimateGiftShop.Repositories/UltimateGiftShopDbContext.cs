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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Order>().HasMany<OrderItem>(s => s.OrderItems).WithOne(r => r.Order).HasForeignKey(s => s.OrderId);
            modelBuilder.Entity<Order>().HasOne<User>(s => s.User).WithOne().HasForeignKey<User>(r=>r.UserId);

            modelBuilder.Entity<OrderItem>().HasOne<CategoryDiscount>(s => s.CategoryDiscount).WithOne().HasForeignKey<CategoryDiscount>(s => s.CategoryDiscountId);
            modelBuilder.Entity<OrderItem>().HasOne<Item>(s => s.Item).WithOne().HasForeignKey<Item>(s => s.ItemId);

            modelBuilder.Entity<Item>().HasOne<Category>(s => s.Category).WithOne().HasForeignKey<Category>(s => s.CategoryId);

            modelBuilder.Entity<CategoryDiscount>().HasOne<Category>(s => s.Category).WithOne().HasForeignKey<Category>(s => s.CategoryId);

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryDiscount> CategoryDiscounts { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }


    }
}
