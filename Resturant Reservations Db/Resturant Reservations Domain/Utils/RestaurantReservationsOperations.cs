using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using ResturantDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant_Reservations_Db.Resturant_Reservations_Domain
{
    public class RestaurantReservationsOperations
    {
        private readonly RestaurantReservationDbContext _context;
        public RestaurantReservationsOperations()
        {
            _context= new RestaurantReservationDbContext();
        }

        public List<Employees> ListManagers()
        {
            var employees = _context.Employees.Where(e => e.position == "Manager").ToList();
            return employees;
        }

        public List<Reservations> GetReservationsByCustomer(int CustomerId)
        {
            var reservations = _context.Reservations.Where(r => r.customer_id== CustomerId).ToList();
            return reservations;
        }

        public void ListOrdersAndMenuItems(int ReservationId)
        {
            var ordersAndMenuItems = _context.Orders
                                       .Where(o => o.reservation_id == ReservationId)
                                       .Join(_context.OrderItems, o => o.order_id, oi => oi.order_id, (o, oi) => new
                                       {
                                           order_id = o.order_id,
                                           OrderItem = oi
                                       })
                                       .Join(_context.MenuItems, joined => joined.OrderItem.item_id, mi => mi.item_id, (joined, mi) => new 
                                       {
                                           order_id = joined.order_id,
                                           MenuItems = new List<MenuItems> { mi }
                                       })
                                       .ToList();

            foreach (var menuItem in ordersAndMenuItems)
            {   
                Console.WriteLine($"Order ID: {menuItem.order_id}");

                Console.WriteLine("Order Items:");
                foreach (var item in menuItem.MenuItems)
                {
                    Console.WriteLine($"  Item ID: {item.item_id}\n" +
                                      $"  Restaurant ID: {item.resturant_id}\n" +
                                      $"  Item Name: {item.name}\n" +
                                      $"  Description: {item.description}\n" +
                                      $"  Price: {item.price}\n");
                }

                Console.WriteLine();
            }
        }

        public decimal CalculateAverageOrderAmount(int EmployeeId)
        {
            var result = _context.Orders.GroupBy(o => o.employee_id)
                .Select(group => new
                {
                    employee_id = group.Key,
                    avg = group.Average(o => o.total_amount)
                }).Where(res => res.employee_id == EmployeeId).SingleOrDefault();

             return result.avg;
        }

    }
}
