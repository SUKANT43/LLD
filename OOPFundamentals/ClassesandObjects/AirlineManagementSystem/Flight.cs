using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineManagementSystem
{
    class Flight
    {
        public string FlightNumber { get; }
        public string Source { get; }
        public string Destination { get; }
        public DateTime DepartureTime { get; }
        public DateTime ArrivalTime { get; }
        public List<Seat> AvilableSeat { get; }

        public Flight(string flightNumber, string source, string destination, DateTime depatureTime, DateTime arrivalTime)
        {
            FlightNumber = flightNumber;
            Source = source;
            Destination = destination;
            DepartureTime = depatureTime;
            ArrivalTime = arrivalTime;
            AvilableSeat = new List<Seat>();
        }
    }
}
