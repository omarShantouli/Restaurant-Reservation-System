using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Resturant_Reservations_Db.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "customer_id", "email", "first_name", "last_name", "phone_number" },
                values: new object[,]
                {
                    { 1, "john@example.com", "John", "Doe", "123-456-7890" },
                    { 2, "alice@example.com", "Alice", "Smith", "987-654-3210" },
                    { 3, "bob@example.com", "Bob", "Johnson", "555-123-4567" },
                    { 4, "emily@example.com", "Emily", "Brown", "789-123-4560" },
                    { 5, "david@example.com", "David", "Wilson", "111-222-3333" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "employee_id", "first_name", "last_name", "position", "resturant_id" },
                values: new object[,]
                {
                    { 1, "John", "Doe", "Manager", 101 },
                    { 2, "Alice", "Smith", "Server", 102 },
                    { 3, "Bob", "Johnson", "Chef", 101 },
                    { 4, "Emily", "Brown", "Waiter", 103 },
                    { 5, "David", "Wilson", "Bartender", 102 }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "item_id", "description", "name", "price", "resturant_id" },
                values: new object[,]
                {
                    { 1, "Delicious burger with cheese", "Burger", 9.99m, 101 },
                    { 2, "Pepperoni pizza with extra cheese", "Pizza", 12.49m, 102 },
                    { 3, "Fresh garden salad with vinaigrette dressing", "Salad", 7.99m, 101 },
                    { 4, "Spaghetti with marinara sauce", "Pasta", 10.99m, 103 },
                    { 5, "Carbonated soft drink", "Soda", 1.99m, 102 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "order_item_id", "item_id", "order_id", "quantity" },
                values: new object[,]
                {
                    { 1, 1, 101, 2m },
                    { 2, 3, 101, 1m },
                    { 3, 2, 102, 3m },
                    { 4, 4, 102, 2m },
                    { 5, 5, 103, 4m }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "order_id", "employee_id", "order_date", "reservation_id", "total_amount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 11, 2, 14, 39, 18, 485, DateTimeKind.Local).AddTicks(9216), 101, 25.99m },
                    { 2, 2, new DateTime(2023, 11, 2, 14, 39, 18, 485, DateTimeKind.Local).AddTicks(9258), 102, 35.49m },
                    { 3, 3, new DateTime(2023, 11, 2, 14, 39, 18, 485, DateTimeKind.Local).AddTicks(9259), 103, 19.99m },
                    { 4, 1, new DateTime(2023, 11, 2, 14, 39, 18, 485, DateTimeKind.Local).AddTicks(9261), 104, 42.75m },
                    { 5, 2, new DateTime(2023, 11, 2, 14, 39, 18, 485, DateTimeKind.Local).AddTicks(9263), 105, 15.99m }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "reservation_id", "customer_id", "party_size", "reservation_date", "resturant_id", "table_id" },
                values: new object[,]
                {
                    { 1, 101, 4, new DateTime(2023, 11, 2, 14, 39, 18, 485, DateTimeKind.Local).AddTicks(9281), 201, 1 },
                    { 2, 102, 6, new DateTime(2023, 11, 2, 14, 39, 18, 485, DateTimeKind.Local).AddTicks(9285), 202, 2 },
                    { 3, 103, 2, new DateTime(2023, 11, 2, 14, 39, 18, 485, DateTimeKind.Local).AddTicks(9287), 201, 3 },
                    { 4, 104, 8, new DateTime(2023, 11, 2, 14, 39, 18, 485, DateTimeKind.Local).AddTicks(9288), 203, 1 },
                    { 5, 105, 5, new DateTime(2023, 11, 2, 14, 39, 18, 485, DateTimeKind.Local).AddTicks(9290), 202, 2 }
                });

            migrationBuilder.InsertData(
                table: "Resturants",
                columns: new[] { "resturant_id", "address", "name", "opening_hours", "phone_number" },
                values: new object[,]
                {
                    { 1, "123 Main St", "Restaurant A", "Mon-Fri: 9 AM - 10 PM, Sat-Sun: 10 AM - 11 PM", "555-123-4567" },
                    { 2, "456 Oak Ave", "Restaurant B", "Mon-Sun: 8 AM - 9 PM", "555-987-6543" },
                    { 3, "789 Elm St", "Restaurant C", "Mon-Fri: 10 AM - 8 PM, Sat-Sun: 11 AM - 7 PM", "555-456-7890" },
                    { 4, "101 Pine Rd", "Restaurant D", "Mon-Sat: 7 AM - 11 PM, Sun: 8 AM - 10 PM", "555-111-2222" },
                    { 5, "202 Maple Ln", "Restaurant E", "Mon-Fri: 11 AM - 9 PM, Sat-Sun: 12 PM - 8 PM", "555-333-4444" }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "table_id", "capacity", "resturant_id" },
                values: new object[,]
                {
                    { 1, 4, 201 },
                    { 2, 6, 201 },
                    { 3, 2, 202 },
                    { 4, 8, 202 },
                    { 5, 4, 203 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "customer_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "customer_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "customer_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "customer_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "customer_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "employee_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "employee_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "employee_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "employee_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "employee_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "item_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "item_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "item_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "item_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "item_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "order_item_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "order_item_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "order_item_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "order_item_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "order_item_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "order_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "order_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "order_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "order_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "order_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "reservation_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "reservation_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "reservation_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "reservation_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "reservation_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Resturants",
                keyColumn: "resturant_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Resturants",
                keyColumn: "resturant_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Resturants",
                keyColumn: "resturant_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Resturants",
                keyColumn: "resturant_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Resturants",
                keyColumn: "resturant_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "table_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "table_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "table_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "table_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "table_id",
                keyValue: 5);
        }
    }
}
