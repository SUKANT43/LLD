using CarRentalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem.Strategy;

namespace CarRentalSystem
{
    class RentalSystem
    {
        private RentalSystem() { }

        private static RentalSystem instance;
        private Dictionary<string, Car> cars = new Dictionary<string, Car>();
        private Dictionary<string, Reservation> reservations = new Dictionary<string, Reservation>();
        private IPaymentProcessor paymentProcessor = new PayPalPaymentProcessor();
        private static readonly object instanceLock = new object();

        public static RentalSystem GetInstance()
        {
            if (instance == null)
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RentalSystem();
                    }
                }
            }

            return instance;
        }

        public void AddCar(Car car)
        {
            cars[car.GetLicensePlate()] = car;
        }

        public void RemoveCar(string licensePlate)
        {
            cars.Remove(licensePlate);
        }

        public List<Car> SearchCars(string make, string model, DateTime startDate, DateTime endDate)
        {
            return cars.Values
                .Where(car => car.GetMake().Equals(make, StringComparison.OrdinalIgnoreCase)
                              && car.GetModel().Equals(model, StringComparison.OrdinalIgnoreCase)
                              && car.IsAvilable() && IsCarAvailable(car, startDate, endDate))
                .ToList();
        }

        private bool IsCarAvailable(Car car, DateTime startDate, DateTime endDate)
        {
            return reservations.Values
                        .Where(reservation => reservation.GetCar() == car)
                        .All(reservation => endDate < reservation.GetStartDate() || startDate > reservation.GetEndDate());

        }

        public Reservation MakeReservation(Customer customer,Car car,DateTime startDate,DateTime endDate)
        {
            if (IsCarAvailable(car, startDate, endDate))
            {
                var reservation = new Reservation(customer, car, startDate, endDate);
                reservations[reservation.GetReservationId()] = reservation;
                car.SetAvilable(false);
                return reservation;
            }
            return null;
        }

        public void CancelReservation(string reservationId)
        {
            if(reservations.TryGetValue(reservationId,out Reservation res))
            {
                reservations.Remove(reservationId);
                res.GetCar().SetAvilable(true);
            }
        }

        public bool ProcessPayment(Reservation reservation)
        {
            return paymentProcessor.ProcessPayment(reservation.TotalPrice());
        }

      

    }
}
