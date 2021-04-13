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
    public partial class Form1 : Form
    {
        public List<Row> RowList = new List<Row>();
        

        public Form1()
        {
            InitializeComponent();

            //initialise 10 rows
            for (int i = 1; i <= 10; i++)
            {
                Row row = new Row(i);
                RowList.Add(row);
            }
        }

        private bool ValidateSeatCount(string textboxValue, ref int seatCount)
        {
            bool isValid = false;


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

        private void button1_Click(object sender, EventArgs e)
        {
            int seatCount = 0;
            bool seatsFound = false;

            if(ValidateSeatCount(textBox1.Text, ref seatCount) == true)
            {
                for (int i = 9; i >= 0; i--)
                {
                    if (RowList[i].CountOfEmptySeats() >= seatCount)
                    {
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
                        label1.Text = $"Your row number is {RowList[i].RowNumber} and your seats are {string.Join(", ", seatNumbers)}";
                        break;
                    }

                }

                if (seatsFound != true)
                {
                    //no seats found
                    label1.Text = "No available seats";
                }
            }
        }
    }
}
