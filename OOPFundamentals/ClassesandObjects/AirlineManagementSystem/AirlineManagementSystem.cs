using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineManagementSystem
{
    class AirlineManagementSystem
    {
        private readonly List<Flight> flights;
        private readonly List<Aircraft> aircrafts;
        private readonly FlightSearch flightSearch;
        private readonly BookingManager bookingManager;
        private readonly PaymentProcessor paymentProcessor;

        public AirlineManagementSystem()
        {
            flights = new List<Flight>();
            aircrafts = new List<Aircraft>();
            flightSearch = new FlightSearch(flights);
            bookingManager = BookingManager.Instance;
            paymentProcessor = PaymentProcessor.Instance;
        }

        public void AddFlight(Flight flight)
        {
            flights.Add(flight);
        }

        public void AddAircraft(Aircraft craft)
        {
            aircrafts.Add(craft);
        }

        public List<Flight> SearchFlights(string source,string destination,DateTime date)
        {
            return flightSearch.SearchFlights(source, destination, date);
        }

        public Booking BookFlight(Flight flight,Passenger passanger,Seat seat,double price)
        {
            return bookingManager.CreateBooking(flight, passanger, seat, price);
        }


        public void CancelBooking(string bookingNumber)
        {
            bookingManager.CancelBooking(bookingNumber);
        }

        public void ProcessPayment(Payment payment)
        {
            paymentProcessor.ProcessPayment(payment);
        }

    }
}
