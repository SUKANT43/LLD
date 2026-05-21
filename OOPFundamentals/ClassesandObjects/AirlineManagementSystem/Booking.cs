using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineManagementSystem
{
    class Booking
    {
        public string BookingNumber { get; }
        public Flight Flight { get; }
        public Passenger Passanger { get; }
        public Seat Seat { get; }
        public double Price { get; }
        public BookingStatus Status{get;private set;}

        public Booking(string bookingNumber,Flight flight,Passenger passanger,Seat seat,double price)
        {
            BookingNumber = bookingNumber;
            Flight = flight;
            Passanger = passanger;
            Seat = seat;
            Price = price;
            Status = BookingStatus.CONFIRMED;
        }

        public void Cancel()
        {
            Status = BookingStatus.CANCELLED;
        }
    }
}
