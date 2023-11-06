using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ResturantDataModel;
using System.Data;

namespace RestaurantReservation.Db
{
    public class RestaurantReservationDbContext : DbContext
    {
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<MenuItems> MenuItems { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<Resturants> Resturants { get; set; }
        public DbSet<Tables> Tables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=OMAR\\SQLEXPRESS;Database=RestaurantReservationCore;Trusted_Connection=True;TrustServerCertificate=True;"
                );
        }

        public decimal CalculateTotalRevenue(int restaurantId)
        {
            var restaurantIdParam = new SqlParameter("@RestaurantId", restaurantId);
            var totalRevenueParam = new SqlParameter
            {
                ParameterName = "@TotalRevenue",
                SqlDbType = SqlDbType.Decimal,
                Precision = 18,
                Scale = 2,
                Direction = ParameterDirection.Output
            };

            Database.ExecuteSqlRaw("SET @TotalRevenue = dbo.CalculateTotalRevenue(@RestaurantId)", restaurantIdParam, totalRevenueParam);

            if (totalRevenueParam.Value is decimal totalRevenue)
            {
                return totalRevenue;
            }

            return 0;

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customers>().HasData(GetCustomerList());
            modelBuilder.Entity<Employees>().HasData(GetEmployeeList());
            modelBuilder.Entity<MenuItems>().HasData(GetMenuItemsList());
            modelBuilder.Entity<OrderItems>().HasData(GetOrderItemsList());
            modelBuilder.Entity<Orders>().HasData(GetOrdersList());
            modelBuilder.Entity<Reservations>().HasData(GetReservationsList());
            modelBuilder.Entity<Resturants>().HasData(GetRestaurantsList());
            modelBuilder.Entity<Tables>().HasData(GetTablesList());
        }

        List<Customers> GetCustomerList()
        {
            return new List<Customers>
            {
                new Customers { customer_id = 1, first_name = "John", last_name = "Doe", email = "john@example.com", phone_number = "123-456-7890" },
                new Customers { customer_id = 2, first_name = "Alice", last_name = "Smith", email = "alice@example.com", phone_number = "987-654-3210" },
                new Customers { customer_id = 3, first_name = "Bob", last_name = "Johnson", email = "bob@example.com", phone_number = "555-123-4567" },
                new Customers { customer_id = 4, first_name = "Emily", last_name = "Brown", email = "emily@example.com", phone_number = "789-123-4560" },
                new Customers { customer_id = 5, first_name = "David", last_name = "Wilson", email = "david@example.com", phone_number = "111-222-3333" }
            };
        }
        List<Employees> GetEmployeeList()
        {
            return new List<Employees>
            {
                new Employees { employee_id = 1, resturant_id = 101, first_name = "John", last_name = "Doe", position = "Manager" },
                new Employees { employee_id = 2, resturant_id = 102, first_name = "Alice", last_name = "Smith", position = "Server" },
                new Employees { employee_id = 3, resturant_id = 101, first_name = "Bob", last_name = "Johnson", position = "Chef" },
                new Employees { employee_id = 4, resturant_id = 103, first_name = "Emily", last_name = "Brown", position = "Waiter" },
                new Employees { employee_id = 5, resturant_id = 102, first_name = "David", last_name = "Wilson", position = "Bartender" }
            };
        }
        List<MenuItems> GetMenuItemsList()
        {
            return new List<MenuItems>
            {
                new MenuItems { item_id = 1, resturant_id = 1, name = "Burger", description = "Delicious burger with cheese", price = 9.99M },
                new MenuItems { item_id = 2, resturant_id = 2, name = "Pizza", description = "Pepperoni pizza with extra cheese", price = 12.49M },
                new MenuItems { item_id = 3, resturant_id = 1, name = "Salad", description = "Fresh garden salad with vinaigrette dressing", price = 7.99M },
                new MenuItems { item_id = 4, resturant_id = 3, name = "Pasta", description = "Spaghetti with marinara sauce", price = 10.99M },
                new MenuItems { item_id = 5, resturant_id = 2, name = "Soda", description = "Carbonated soft drink", price = 1.99M }
            };
        }
        List<OrderItems> GetOrderItemsList()
        {
            return new List<OrderItems>
            {
                new OrderItems { order_item_id = 1, order_id = 1, item_id = 1, quantity = 2 },
                new OrderItems { order_item_id = 2, order_id = 1, item_id = 3, quantity = 1 },
                new OrderItems { order_item_id = 3, order_id = 2, item_id = 2, quantity = 3 },
                new OrderItems { order_item_id = 4, order_id = 2, item_id = 4, quantity = 2 },
                new OrderItems { order_item_id = 5, order_id = 3, item_id = 5, quantity = 4 }
            };
        }
        List<Orders> GetOrdersList()
        {
            return new List<Orders>
            {
                new Orders { order_id = 1, reservation_id = 1, employee_id = 1, order_date = new DateTime(2023, 11, 5, 15, 0, 0), total_amount = 25.99M },
                new Orders { order_id = 2, reservation_id = 2, employee_id = 2, order_date = new DateTime(2023, 11, 4, 4, 30, 0), total_amount = 35.49M },
                new Orders { order_id = 3, reservation_id = 3, employee_id = 3, order_date = new DateTime(2023, 11, 7, 4, 0, 0), total_amount = 19.99M },
                new Orders { order_id = 4, reservation_id = 4, employee_id = 1, order_date = new DateTime(2023, 11, 5, 3, 0, 0), total_amount = 42.75M },
                new Orders { order_id = 5, reservation_id = 5, employee_id = 2, order_date = new DateTime(2023, 11, 4, 2, 15, 0), total_amount = 15.99M }
            };
        }
        List<Reservations> GetReservationsList()
        {
            return new List<Reservations>
            {
                new Reservations { reservation_id = 1, customer_id = 1, resturant_id = 1, table_id = 1, reservation_date = new DateTime(2023, 11, 1, 10, 0, 0), party_size = 4 },
                new Reservations { reservation_id = 2, customer_id = 2, resturant_id = 2, table_id = 2, reservation_date = new DateTime(2023, 1, 5, 14, 0, 0), party_size = 6 },
                new Reservations { reservation_id = 3, customer_id = 3, resturant_id = 1, table_id = 3, reservation_date = new DateTime(2023, 12, 2, 17, 30, 0), party_size = 2 },
                new Reservations { reservation_id = 4, customer_id = 4, resturant_id = 3, table_id = 1, reservation_date = new DateTime(2023, 10, 7, 16, 0, 0), party_size = 8 },
                new Reservations { reservation_id = 5, customer_id = 5, resturant_id = 2, table_id = 2, reservation_date = new DateTime(2023, 11, 5, 15, 15, 0), party_size = 5 }
            };
        }
        List<Resturants> GetRestaurantsList()
        {
            return new List<Resturants>
            {
                new Resturants
                {
                    resturant_id = 1,
                    name = "Restaurant A",
                    address = "123 Main St",
                    phone_number = "555-123-4567",
                    opening_hours = "Mon-Fri: 9 AM - 10 PM, Sat-Sun: 10 AM - 11 PM"
                },
                new Resturants
                {
                    resturant_id = 2,
                    name = "Restaurant B",
                    address = "456 Oak Ave",
                    phone_number = "555-987-6543",
                    opening_hours = "Mon-Sun: 8 AM - 9 PM"
                },
                new Resturants
                {
                    resturant_id = 3,
                    name = "Restaurant C",
                    address = "789 Elm St",
                    phone_number = "555-456-7890",
                    opening_hours = "Mon-Fri: 10 AM - 8 PM, Sat-Sun: 11 AM - 7 PM"
                },
                new Resturants
                {
                    resturant_id = 4,
                    name = "Restaurant D",
                    address = "101 Pine Rd",
                    phone_number = "555-111-2222",
                    opening_hours = "Mon-Sat: 7 AM - 11 PM, Sun: 8 AM - 10 PM"
                },
                new Resturants
                {
                    resturant_id = 5,
                    name = "Restaurant E",
                    address = "202 Maple Ln",
                    phone_number = "555-333-4444",
                    opening_hours = "Mon-Fri: 11 AM - 9 PM, Sat-Sun: 12 PM - 8 PM"
                },
            };
        }
        List<Tables> GetTablesList()
        {
            return new List<Tables>
            {
                new Tables { table_id = 1, resturant_id = 1, capacity = 4 },
                new Tables { table_id = 2, resturant_id = 1, capacity = 6 },
                new Tables { table_id = 3, resturant_id = 2, capacity = 2 },
                new Tables { table_id = 4, resturant_id = 2, capacity = 8 },
                new Tables { table_id = 5, resturant_id = 3, capacity = 4 },
            };
        }

    }
}