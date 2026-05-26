using CarRentalSystem.Models;
using System;
using System.Collections.Generic;

namespace CarRentalSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            RentalSystem rentalSystem = RentalSystem.GetInstance();

            // Add Cars
            rentalSystem.AddCar(
                new Car("Toyota", "Camry", 2022, "ABC123", 50.0));

            rentalSystem.AddCar(
                new Car("Honda", "Civic", 2021, "XYZ789", 45.0));

            rentalSystem.AddCar(
                new Car("Ford", "Mustang", 2023, "DEF456", 80.0));

            Console.WriteLine("===== TEST CASE 1 =====");
            Console.WriteLine("Search + Reservation + Payment");

            var startDate = DateTime.Now;
            var endDate = startDate.AddDays(3);

            Customer customer1 =
                new Customer(
                    "John Doe",
                    "john@example.com",
                    "DL1234");

            List<Car> availableCars =
                rentalSystem.SearchCars(
                    "Toyota",
                    "Camry",
                    startDate,
                    endDate);

            Console.WriteLine(
                "Available Cars Count: " +
                availableCars.Count);

            if (availableCars.Count > 0)
            {
                Car selectedCar = availableCars[0];

                var reservation =
                    rentalSystem.MakeReservation(
                        customer1,
                        selectedCar,
                        startDate,
                        endDate);

                if (reservation != null)
                {
                    Console.WriteLine(
                        "Reservation Created");

                    bool paymentSuccess =
                        rentalSystem.ProcessPayment(
                            reservation);

                    Console.WriteLine(
                        "Payment Status: " +
                        paymentSuccess);

                    if (paymentSuccess)
                    {
                        Console.WriteLine(
                            "Reservation Success. ID: " +
                            reservation.GetReservationId());
                    }
                    else
                    {
                        Console.WriteLine(
                            "Payment Failed");

                        rentalSystem.CancelReservation(
                            reservation.GetReservationId());
                    }
                }
                else
                {
                    Console.WriteLine(
                        "Reservation Failed");
                }
            }

            Console.WriteLine();
            Console.WriteLine("===== TEST CASE 2 =====");
            Console.WriteLine("Try Double Booking Same Car");

            Customer customer2 =
                new Customer(
                    "David",
                    "david@example.com",
                    "DL5678");

            List<Car> sameCarSearch =
                rentalSystem.SearchCars(
                    "Toyota",
                    "Camry",
                    startDate,
                    endDate);

            Console.WriteLine(
                "Available Cars Count: " +
                sameCarSearch.Count);

            if (sameCarSearch.Count > 0)
            {
                var reservation2 =
                    rentalSystem.MakeReservation(
                        customer2,
                        sameCarSearch[0],
                        startDate,
                        endDate);

                if (reservation2 != null)
                {
                    Console.WriteLine(
                        "Double Booking Allowed ❌");
                }
                else
                {
                    Console.WriteLine(
                        "Double Booking Prevented ✅");
                }
            }
            else
            {
                Console.WriteLine(
                    "Car Not Available (Expected)");
            }

            Console.WriteLine();
            Console.WriteLine("===== TEST CASE 3 =====");
            Console.WriteLine("Invalid Car Search");

            List<Car> invalidSearch =
                rentalSystem.SearchCars(
                    "BMW",
                    "X5",
                    startDate,
                    endDate);

            Console.WriteLine(
                "Available Cars Count: " +
                invalidSearch.Count);

            if (invalidSearch.Count == 0)
            {
                Console.WriteLine(
                    "Invalid Search Passed ✅");
            }
            else
            {
                Console.WriteLine(
                    "Invalid Search Failed ❌");
            }

            Console.WriteLine();
            Console.WriteLine("===== TEST CASE 4 =====");
            Console.WriteLine("Singleton Test");

            RentalSystem rs1 =
                RentalSystem.GetInstance();

            RentalSystem rs2 =
                RentalSystem.GetInstance();

            Console.WriteLine(
                "Same Instance: " +
                (rs1 == rs2));

            Console.ReadLine();
        }
    }
}