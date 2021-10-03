﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Transauto.Services.ProductAPI.DbContexts;

namespace Transauto.Services.ProductAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211003010752_SeedProducts")]
    partial class SeedProducts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Transauto.Services.ProductAPI.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryName = "Entree",
                            Description = "fried triangular shaped pastry with a savory filling like spiced onions, beef meat, and other ingredients",
                            ImageUrl = "https://transautostatifiles.blob.core.windows.net/productimages/sambusa.jpg",
                            Name = "Sambusa",
                            Price = 12.4
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryName = "Dessert",
                            Description = "a layered pastry dessert made of filo pastry, filled with chopped nuts, and sweetened with syrup or honey",
                            ImageUrl = "https://transautostatifiles.blob.core.windows.net/productimages/baklava.jpg",
                            Name = "Baklava",
                            Price = 2.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
