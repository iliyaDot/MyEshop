using Microsoft.EntityFrameworkCore;
using MyEshop.Models;

namespace MyEshop.Data
{
    public class MyEshopContext : DbContext
    {
        public MyEshopContext(DbContextOptions<MyEshopContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryToProduct> categoryToProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define composite primary key for CategoryToProduct
            modelBuilder.Entity<CategoryToProduct>()
                .HasKey(t => new { t.ProductId, t.CategoryId });

            modelBuilder.Entity<Item>(i =>
            {
                i.Property(w => w.Price).HasColumnType("money");
                i.HasKey(w => w.Id);
            });

            #region Seed Data

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "asp . net core", Description = "asp core 3" },
                new Category() { Id = 2, Name = "Sport Shirt", Description = "Sport Group" },
                new Category() { Id = 3, Name = "HandWatch", Description = "HandWatch" }
            );

            // Seed Items
            modelBuilder.Entity<Item>().HasData(
                new Item() { Id = 1, Price = 221.2M, QuantityInStock = 5 },
                new Item() { Id = 2, Price = 854.0M, QuantityInStock = 8 },
                new Item() { Id = 3, Price = 312.0M, QuantityInStock = 3 }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, ItemId = 1, Name = "Laptop", Description = "A high-performance laptop for gaming and work." },
                new Product() { Id = 2, ItemId = 2, Name = "Smartphone", Description = "A flagship smartphone with an amazing camera." },
                new Product() { Id = 3, ItemId = 3, Name = "Wireless Headphones", Description = "Noise-canceling wireless headphones with great battery life." }
            );

            // Seed CategoryToProduct Relationships
            modelBuilder.Entity<CategoryToProduct>().HasData(
                new CategoryToProduct() { CategoryId = 1, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 1 },

                new CategoryToProduct() { CategoryId = 1, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 2 },

                new CategoryToProduct() { CategoryId = 1, ProductId = 3 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 3 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 3 }
            );

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
