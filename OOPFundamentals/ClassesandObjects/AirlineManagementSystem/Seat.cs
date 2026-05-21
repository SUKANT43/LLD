using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineManagementSystem
{
    class Seat
    {
        public string SeatNumber { get; }
        public SeatType Type { get; }
        public SeatStatus Status { get; private set; }

        public Seat(string seatNumber, SeatType type)
        {
            SeatNumber = seatNumber;
            Type = type;
            Status = SeatStatus.AVILABLE;
        }

        public void Reserve()
        {
            Status = SeatStatus.RESERVED;
        }

        public void Release()
        {
            Status = SeatStatus.AVILABLE;
        }

    }
}
