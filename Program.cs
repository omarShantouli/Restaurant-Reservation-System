using System;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using Resturant_Reservations_Db.Resturant_Reservations_Domain;
using ResturantDataModel;

namespace RestaurantReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerRepository = new Repository<Customers>();
            var restrepo = new Repository<Resturants>();

            Customers customer = new Customers
            {
                first_name = "Ahmed",
                last_name = "Turkman",
                email = "Turkman.doe@example.com",
                phone_number = "+1-555-555-5555"
            };
            customerRepository.Create(customer);

            customerRepository.Delete(customer.customer_id);

            var rests = restrepo.GetAll();
            foreach (var restaurant in rests)
            {
                Console.WriteLine(restaurant.address + " " + restaurant.name);
            }

            var restaurantReservationsOperations = new RestaurantReservationsOperations();

            var employees = restaurantReservationsOperations.ListManagers();
            foreach (var e in employees)
            {
                Console.WriteLine(e.first_name + " " + e.last_name);
            }

            var reservations = restaurantReservationsOperations.GetReservationsByCustomer(103);
            foreach (var reservation in reservations)
            {
                Console.WriteLine(reservation.reservation_id + " " + reservation.reservation_date);
            }

            restaurantReservationsOperations.ListOrdersAndMenuItems(1);
            Console.WriteLine(restaurantReservationsOperations.CalculateAverageOrderAmount(3));

        }


    }
}
