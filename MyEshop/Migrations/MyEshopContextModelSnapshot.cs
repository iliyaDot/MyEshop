﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyEshop.Data;

#nullable disable

namespace MyEshop.Migrations
{
    [DbContext(typeof(MyEshopContext))]
    partial class MyEshopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyEshop.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "asp core 3",
                            Name = "asp . net core"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Sport Group",
                            Name = "Sport Shirt"
                        },
                        new
                        {
                            Id = 3,
                            Description = "HandWatch",
                            Name = "HandWatch"
                        });
                });

            modelBuilder.Entity("MyEshop.Models.CategoryToProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("categoryToProducts");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1
                        },
                        new
                        {
                            ProductId = 1,
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = 1,
                            CategoryId = 3
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 3
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 1
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 3
                        });
                });

            modelBuilder.Entity("MyEshop.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MyProperty")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MyProperty = 0,
                            Price = 221.2m,
                            QuantityInStock = 5
                        },
                        new
                        {
                            Id = 2,
                            MyProperty = 0,
                            Price = 854.0m,
                            QuantityInStock = 8
                        },
                        new
                        {
                            Id = 3,
                            MyProperty = 0,
                            Price = 312.0m,
                            QuantityInStock = 3
                        });
                });

            modelBuilder.Entity("MyEshop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A high-performance laptop for gaming and work.",
                            ItemId = 1,
                            Name = "Laptop"
                        },
                        new
                        {
                            Id = 2,
                            Description = "A flagship smartphone with an amazing camera.",
                            ItemId = 2,
                            Name = "Smartphone"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Noise-canceling wireless headphones with great battery life.",
                            ItemId = 3,
                            Name = "Wireless Headphones"
                        });
                });

            modelBuilder.Entity("MyEshop.Models.CategoryToProduct", b =>
                {
                    b.HasOne("MyEshop.Models.Category", "Category")
                        .WithMany("categoryToProducts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyEshop.Models.Product", "Product")
                        .WithMany("categoryToProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MyEshop.Models.Product", b =>
                {
                    b.HasOne("MyEshop.Models.Item", "Item")
                        .WithOne("Product")
                        .HasForeignKey("MyEshop.Models.Product", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("MyEshop.Models.Category", b =>
                {
                    b.Navigation("categoryToProducts");
                });

            modelBuilder.Entity("MyEshop.Models.Item", b =>
                {
                    b.Navigation("Product")
                        .IsRequired();
                });

            modelBuilder.Entity("MyEshop.Models.Product", b =>
                {
                    b.Navigation("categoryToProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
