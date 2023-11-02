using System;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using ResturantDataModel;

namespace RestaurantReservation
{
    class Program
    {
        static void Main(string[] args)
        {


            // Add new reservation
            Reservations reservation = new Reservations
            {
                customer_id = 4,
                resturant_id = 2,
                table_id = 1,
                reservation_date = DateTime.Now,
                party_size = 4
            };

           // AddReservation(reservation);


            //// Query reservations
            //var reservations = context.Reservations.Include(r => r.Table).ToList();
            //foreach (var reservation in reservations)
            //{
            //    Console.WriteLine($"Reservation ID: {reservation.ReservationId}, Customer: {reservation.CustomerName}, Table: {reservation.Table.TableName}");
            //}

        }
        static void AddReservation(Reservations reservation)
        {
            using(var context = new RestaurantReservationDbContext())
            {
                context.Reservations.Add(reservation);
                context.SaveChanges();
            }
            
        }
    }
}
