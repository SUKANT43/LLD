using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineManagementSystem
{
    class FlightSearch
    {
        private readonly List<Flight> flights;



        public FlightSearch(List<Flight> flights)
        {
            this.flights = flights;
        }

        public List<Flight> SearchFlights(string source, string destination, DateTime date)
        {
            return flights.Where(flight => flight.Source.Equals(source, StringComparison.OrdinalIgnoreCase)
                               && flight.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase)
                               && flight.DepartureTime.Date == date.Date).ToList();

        }
    }
}
