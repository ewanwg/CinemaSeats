using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TechTestSeatBooking
{
    public class Row
    {

        public int RowNumber { get; set; }
        public List<Seat> Seats { get; set; }

        public int CountOfEmptySeats()
        {
            //int emptySeats = 0;

            //foreach (Seat seat in Seats)
            //{
            //    if (seat.IsAllocated == false)
            //    {
            //        emptySeats++;
            //    }
            //}

            //return emptySeats;

            return Seats.Where(seat => !seat.IsAllocated).Count();
        }

        public Row(int rowNumber)
        {
            RowNumber = rowNumber;
            Seats = new List<Seat>();

            for (int i = 1; i <= 6; i++)
            {
                Seat seat = new Seat();
                seat.SeatNumber = i;
                seat.IsAllocated = false;

                Seats.Add(seat);
            }
            
            
        }
            

    }
}
