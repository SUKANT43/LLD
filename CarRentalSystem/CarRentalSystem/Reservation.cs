using CarRentalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem
{
    class Reservation
    {
        private string reservationId;
        private Customer customer;
        private Car car;
        private DateTime startDate;
        private DateTime endDate;
        private double totalPrice;


        private string GenerateReservationId()
        {
            return "RES" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
        }

        public Reservation(Customer customer,Car car,DateTime startDate,DateTime endDate)
        {
            this.reservationId = GenerateReservationId();
            this.customer = customer;
            this.car = car;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public DateTime GetStartDate()
        {
            return startDate;
        }

        public DateTime GetEndDate()
        {
            return endDate;
        }

        public Car GetCar()
        {
            return car;
        }

        public double GetCarPrice()
        {
            return 0;
        }

        public string GetReservationId()
        {
            return reservationId;
        }

        public double TotalPrice()
        {
            int daysRented = (endDate - startDate).Days + 1;
            return car.GetRentalPricePerDay() * daysRented;
        }

    }
}
