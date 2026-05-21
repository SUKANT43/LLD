using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineManagementSystem
{
    public class Aircraft
    {
        public string TailNumber { get; }
        public string Model { get; }
        public int TotalSeats { get; }

        public Aircraft(string tailNumber,string model,int totalSeats)
        {
            TailNumber = tailNumber;
            Model = model;
            TotalSeats = totalSeats;
        }

    }
}
