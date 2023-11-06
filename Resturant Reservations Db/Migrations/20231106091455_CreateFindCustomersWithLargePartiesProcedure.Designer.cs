﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantReservation.Db;

#nullable disable

namespace Resturant_Reservations_Db.Migrations
{
    [DbContext(typeof(RestaurantReservationDbContext))]
    [Migration("20231106091455_CreateFindCustomersWithLargePartiesProcedure")]
    partial class CreateFindCustomersWithLargePartiesProcedure
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ResturantDataModel.Customers", b =>
                {
                    b.Property<int>("customer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("customer_id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("customer_id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            customer_id = 1,
                            email = "john@example.com",
                            first_name = "John",
                            last_name = "Doe",
                            phone_number = "123-456-7890"
                        },
                        new
                        {
                            customer_id = 2,
                            email = "alice@example.com",
                            first_name = "Alice",
                            last_name = "Smith",
                            phone_number = "987-654-3210"
                        },
                        new
                        {
                            customer_id = 3,
                            email = "bob@example.com",
                            first_name = "Bob",
                            last_name = "Johnson",
                            phone_number = "555-123-4567"
                        },
                        new
                        {
                            customer_id = 4,
                            email = "emily@example.com",
                            first_name = "Emily",
                            last_name = "Brown",
                            phone_number = "789-123-4560"
                        },
                        new
                        {
                            customer_id = 5,
                            email = "david@example.com",
                            first_name = "David",
                            last_name = "Wilson",
                            phone_number = "111-222-3333"
                        });
                });

            modelBuilder.Entity("ResturantDataModel.Employees", b =>
                {
                    b.Property<int>("employee_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("employee_id"));

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("resturant_id")
                        .HasColumnType("int");

                    b.HasKey("employee_id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            employee_id = 1,
                            first_name = "John",
                            last_name = "Doe",
                            position = "Manager",
                            resturant_id = 101
                        },
                        new
                        {
                            employee_id = 2,
                            first_name = "Alice",
                            last_name = "Smith",
                            position = "Server",
                            resturant_id = 102
                        },
                        new
                        {
                            employee_id = 3,
                            first_name = "Bob",
                            last_name = "Johnson",
                            position = "Chef",
                            resturant_id = 101
                        },
                        new
                        {
                            employee_id = 4,
                            first_name = "Emily",
                            last_name = "Brown",
                            position = "Waiter",
                            resturant_id = 103
                        },
                        new
                        {
                            employee_id = 5,
                            first_name = "David",
                            last_name = "Wilson",
                            position = "Bartender",
                            resturant_id = 102
                        });
                });

            modelBuilder.Entity("ResturantDataModel.MenuItems", b =>
                {
                    b.Property<int>("item_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("item_id"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("resturant_id")
                        .HasColumnType("int");

                    b.HasKey("item_id");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            item_id = 1,
                            description = "Delicious burger with cheese",
                            name = "Burger",
                            price = 9.99m,
                            resturant_id = 1
                        },
                        new
                        {
                            item_id = 2,
                            description = "Pepperoni pizza with extra cheese",
                            name = "Pizza",
                            price = 12.49m,
                            resturant_id = 2
                        },
                        new
                        {
                            item_id = 3,
                            description = "Fresh garden salad with vinaigrette dressing",
                            name = "Salad",
                            price = 7.99m,
                            resturant_id = 1
                        },
                        new
                        {
                            item_id = 4,
                            description = "Spaghetti with marinara sauce",
                            name = "Pasta",
                            price = 10.99m,
                            resturant_id = 3
                        },
                        new
                        {
                            item_id = 5,
                            description = "Carbonated soft drink",
                            name = "Soda",
                            price = 1.99m,
                            resturant_id = 2
                        });
                });

            modelBuilder.Entity("ResturantDataModel.OrderItems", b =>
                {
                    b.Property<int>("order_item_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("order_item_id"));

                    b.Property<int>("item_id")
                        .HasColumnType("int");

                    b.Property<int>("order_id")
                        .HasColumnType("int");

                    b.Property<decimal>("quantity")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("order_item_id");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            order_item_id = 1,
                            item_id = 1,
                            order_id = 1,
                            quantity = 2m
                        },
                        new
                        {
                            order_item_id = 2,
                            item_id = 3,
                            order_id = 1,
                            quantity = 1m
                        },
                        new
                        {
                            order_item_id = 3,
                            item_id = 2,
                            order_id = 2,
                            quantity = 3m
                        },
                        new
                        {
                            order_item_id = 4,
                            item_id = 4,
                            order_id = 2,
                            quantity = 2m
                        },
                        new
                        {
                            order_item_id = 5,
                            item_id = 5,
                            order_id = 3,
                            quantity = 4m
                        });
                });

            modelBuilder.Entity("ResturantDataModel.Orders", b =>
                {
                    b.Property<int>("order_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("order_id"));

                    b.Property<int>("employee_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("order_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("reservation_id")
                        .HasColumnType("int");

                    b.Property<decimal>("total_amount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("order_id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            order_id = 1,
                            employee_id = 1,
                            order_date = new DateTime(2023, 11, 5, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            reservation_id = 1,
                            total_amount = 25.99m
                        },
                        new
                        {
                            order_id = 2,
                            employee_id = 2,
                            order_date = new DateTime(2023, 11, 4, 4, 30, 0, 0, DateTimeKind.Unspecified),
                            reservation_id = 2,
                            total_amount = 35.49m
                        },
                        new
                        {
                            order_id = 3,
                            employee_id = 3,
                            order_date = new DateTime(2023, 11, 7, 4, 0, 0, 0, DateTimeKind.Unspecified),
                            reservation_id = 3,
                            total_amount = 19.99m
                        },
                        new
                        {
                            order_id = 4,
                            employee_id = 1,
                            order_date = new DateTime(2023, 11, 5, 3, 0, 0, 0, DateTimeKind.Unspecified),
                            reservation_id = 4,
                            total_amount = 42.75m
                        },
                        new
                        {
                            order_id = 5,
                            employee_id = 2,
                            order_date = new DateTime(2023, 11, 4, 2, 15, 0, 0, DateTimeKind.Unspecified),
                            reservation_id = 5,
                            total_amount = 15.99m
                        });
                });

            modelBuilder.Entity("ResturantDataModel.Reservations", b =>
                {
                    b.Property<int>("reservation_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("reservation_id"));

                    b.Property<int>("customer_id")
                        .HasColumnType("int");

                    b.Property<int>("party_size")
                        .HasColumnType("int");

                    b.Property<DateTime>("reservation_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("resturant_id")
                        .HasColumnType("int");

                    b.Property<int>("table_id")
                        .HasColumnType("int");

                    b.HasKey("reservation_id");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            reservation_id = 1,
                            customer_id = 1,
                            party_size = 4,
                            reservation_date = new DateTime(2023, 11, 1, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            resturant_id = 1,
                            table_id = 1
                        },
                        new
                        {
                            reservation_id = 2,
                            customer_id = 2,
                            party_size = 6,
                            reservation_date = new DateTime(2023, 1, 5, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            resturant_id = 2,
                            table_id = 2
                        },
                        new
                        {
                            reservation_id = 3,
                            customer_id = 3,
                            party_size = 2,
                            reservation_date = new DateTime(2023, 12, 2, 17, 30, 0, 0, DateTimeKind.Unspecified),
                            resturant_id = 1,
                            table_id = 3
                        },
                        new
                        {
                            reservation_id = 4,
                            customer_id = 4,
                            party_size = 8,
                            reservation_date = new DateTime(2023, 10, 7, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            resturant_id = 3,
                            table_id = 1
                        },
                        new
                        {
                            reservation_id = 5,
                            customer_id = 5,
                            party_size = 5,
                            reservation_date = new DateTime(2023, 11, 5, 15, 15, 0, 0, DateTimeKind.Unspecified),
                            resturant_id = 2,
                            table_id = 2
                        });
                });

            modelBuilder.Entity("ResturantDataModel.Resturants", b =>
                {
                    b.Property<int>("resturant_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("resturant_id"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("opening_hours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("resturant_id");

                    b.ToTable("Resturants");

                    b.HasData(
                        new
                        {
                            resturant_id = 1,
                            address = "123 Main St",
                            name = "Restaurant A",
                            opening_hours = "Mon-Fri: 9 AM - 10 PM, Sat-Sun: 10 AM - 11 PM",
                            phone_number = "555-123-4567"
                        },
                        new
                        {
                            resturant_id = 2,
                            address = "456 Oak Ave",
                            name = "Restaurant B",
                            opening_hours = "Mon-Sun: 8 AM - 9 PM",
                            phone_number = "555-987-6543"
                        },
                        new
                        {
                            resturant_id = 3,
                            address = "789 Elm St",
                            name = "Restaurant C",
                            opening_hours = "Mon-Fri: 10 AM - 8 PM, Sat-Sun: 11 AM - 7 PM",
                            phone_number = "555-456-7890"
                        },
                        new
                        {
                            resturant_id = 4,
                            address = "101 Pine Rd",
                            name = "Restaurant D",
                            opening_hours = "Mon-Sat: 7 AM - 11 PM, Sun: 8 AM - 10 PM",
                            phone_number = "555-111-2222"
                        },
                        new
                        {
                            resturant_id = 5,
                            address = "202 Maple Ln",
                            name = "Restaurant E",
                            opening_hours = "Mon-Fri: 11 AM - 9 PM, Sat-Sun: 12 PM - 8 PM",
                            phone_number = "555-333-4444"
                        });
                });

            modelBuilder.Entity("ResturantDataModel.Tables", b =>
                {
                    b.Property<int>("table_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("table_id"));

                    b.Property<int>("capacity")
                        .HasColumnType("int");

                    b.Property<int>("resturant_id")
                        .HasColumnType("int");

                    b.HasKey("table_id");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            table_id = 1,
                            capacity = 4,
                            resturant_id = 1
                        },
                        new
                        {
                            table_id = 2,
                            capacity = 6,
                            resturant_id = 1
                        },
                        new
                        {
                            table_id = 3,
                            capacity = 2,
                            resturant_id = 2
                        },
                        new
                        {
                            table_id = 4,
                            capacity = 8,
                            resturant_id = 2
                        },
                        new
                        {
                            table_id = 5,
                            capacity = 4,
                            resturant_id = 3
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
