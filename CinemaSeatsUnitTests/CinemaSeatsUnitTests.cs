using TechTestSeatBooking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace CinemaSeatsUnitTests
{
    [TestClass]
    public class CinemaSeatsUnitTests
    {
        [TestMethod]
        public void Check_User_Input_Is_Valid_String()
        {
            // Arrange
            BookingForm form = new BookingForm();
            
            // Act
            string textUserInput = "string input";
            int seatCount = 0;
            
            // Assert
            Assert.IsFalse(form.ValidateSeatCount(textUserInput, ref seatCount));
            
        }

        [TestMethod]
        public void Check_User_Input_Is_Valid_Int_Upper_Bounds()
        {
            // Arrange
            BookingForm form = new BookingForm();

            // Act
            string textUserInput = "7";
            int seatCount = 0;

            // Assert
            Assert.IsFalse(form.ValidateSeatCount(textUserInput, ref seatCount));

        }

        [TestMethod]
        public void Check_User_Input_Is_Valid_Int_Lower_Bounds()
        {
            // Arrange
            BookingForm form = new BookingForm();

            // Act
            string textUserInput = "0";
            int seatCount = 0;

            // Assert
            Assert.IsFalse(form.ValidateSeatCount(textUserInput, ref seatCount));

        }
    }
}
