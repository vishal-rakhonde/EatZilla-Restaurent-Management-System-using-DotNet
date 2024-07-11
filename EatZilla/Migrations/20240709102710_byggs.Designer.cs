﻿// <auto-generated />
using EatZilla.Models.DataConnection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EatZilla.Migrations
{
    [DbContext(typeof(ApplicationDatabaseContext))]
    [Migration("20240709102710_byggs")]
    partial class byggs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("EatZilla.Models.CoreClasses.Dish", b =>
                {
                    b.Property<int>("DishId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("DishId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.HasKey("DishId");

                    b.ToTable("dishes");

                    b.HasData(
                        new
                        {
                            DishId = 1,
                            Name = "Biryani",
                            price = 220
                        },
                        new
                        {
                            DishId = 2,
                            Name = "Dal-Khichadi",
                            price = 120
                        },
                        new
                        {
                            DishId = 3,
                            Name = "Rice-plate",
                            price = 150
                        },
                        new
                        {
                            DishId = 4,
                            Name = "Chicken-Thali",
                            price = 300
                        },
                        new
                        {
                            DishId = 5,
                            Name = "Panner",
                            price = 180
                        });
                });

            modelBuilder.Entity("EatZilla.Models.CoreClasses.Resturant", b =>
                {
                    b.Property<int>("Rid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Rid"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Rid");

                    b.ToTable("resturants");

                    b.HasData(
                        new
                        {
                            Rid = 101,
                            Name = "Taksh",
                            OrderID = 0,
                            type = "Veg"
                        },
                        new
                        {
                            Rid = 102,
                            Name = "Nadbrhma",
                            OrderID = 0,
                            type = "Snacks"
                        },
                        new
                        {
                            Rid = 103,
                            Name = "Mataji",
                            OrderID = 0,
                            type = "Sweet"
                        },
                        new
                        {
                            Rid = 104,
                            Name = "Ashirwad",
                            OrderID = 0,
                            type = "NonVeg"
                        });
                });

            modelBuilder.Entity("EatZilla.Models.CoreClasses.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
