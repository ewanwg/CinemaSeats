using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechTestSeatBooking
{
    public partial class BookingForm : Form
    {
        public List<Row> RowList = new List<Row>();


        public BookingForm()
        {
            InitializeComponent();

            //initialise 10 rows of 6 seats
            for (int i = 1; i <= 10; i++)
            {
                Row row = new Row(i);
                RowList.Add(row);
            }
        }

        //Method to check user input is >0 and <7, plus check data type can get parsed correctly
        public bool ValidateSeatCount(string textboxValue, ref int seatCount)
        {
            bool isValid = false; //flag variable


            if (int.TryParse(textboxValue, out seatCount) == true)
            {
                if (seatCount > 6 || seatCount < 0)
                {
                    label1.Text = "Please choose a number less than 7";
                }
                else
                {
                    isValid = true;
                }
            }
            else
            {
                label1.Text = "Please enter a number";
            }

            return isValid;
        }

        //Get seats found
        private void GetSeatCount(ref int seatCount, ref bool seatsFound)
        {
            for (int i = 9; i >= 0; i--)
            {
                //go into list if list has empty seats
                if (RowList[i].CountOfEmptySeats() >= seatCount)
                {
                    //check each seat in the list to find the empty seat number, add it to list seatNumbers, then mark as allocated
                    List<string> seatNumbers = new List<string>();
                    foreach (Seat seat in RowList[i].Seats)
                    {
                        if (!seat.IsAllocated && seatNumbers.Count < seatCount)
                        {
                            seatNumbers.Add(seat.SeatNumber.ToString());
                            seat.IsAllocated = true;

                            seatsFound = true;
                        }
                    }
                    //return row and seat number
                    label1.Text = $"Your row number is {RowList[i].RowNumber} and your seats are {string.Join(", ", seatNumbers)}";
                    break;
                }

            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int seatCount = 0; //set seatcount to 0 prior to user input
            bool seatsFound = false; //flag variable

            if(ValidateSeatCount(textBox1.Text, ref seatCount) == true)
            {
                GetSeatCount(ref seatCount, ref seatsFound);

                if (seatsFound != true)
                {
                    //no seats found
                    label1.Text = "No available seats";
                }
            }
        }
    }
}
