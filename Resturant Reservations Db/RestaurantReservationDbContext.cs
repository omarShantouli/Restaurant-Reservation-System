using Microsoft.EntityFrameworkCore;
using ResturantDataModel;

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
            optionsBuilder.UseSqlServer("Server=OMAR\\SQLEXPRESS;Database=RestaurantReservationCore;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}