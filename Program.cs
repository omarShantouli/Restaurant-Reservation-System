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
            Customers customer = new Customers
            {
                first_name = "Ahmed",
                last_name = "Turkman",
                email = "Turkman.doe@example.com",
                phone_number = "+1-555-555-5555"
            };
           // customerRepository.Create(customer);
            customerRepository.Delete(1002);
        }

      
    }
}
