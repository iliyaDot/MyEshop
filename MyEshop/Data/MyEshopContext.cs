using Microsoft.EntityFrameworkCore;
using MyEshop.Models;

namespace MyEshop.Data
{
    public class MyEshopContext:DbContext
    {

        public MyEshopContext(DbContextOptions<MyEshopContext> options):base(options) 
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryToProduct> categoryToProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seed Data Category
            modelBuilder.Entity<Category>().HasData(new Category()
            {
                Id=1,
                Name="asp . net core",
                Description="asp core 3",

            },
            new Category()
            {
                Id = 2,
                Name = "Sport Shirt",
                Description = "Sport Group",

            },
                   new Category()
                   {
                       Id =3 ,
                       Name = "HandWatch",
                       Description = "HandWatch",

                   }
                

                );
   #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
