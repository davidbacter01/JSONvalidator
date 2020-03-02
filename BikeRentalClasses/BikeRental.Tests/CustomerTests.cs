using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BikeRentalClasses.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void CustomerThatRentsOneSportBikeForADayShouldReturnCorrectTotalAmount()
        {
            Customer nelu = new Customer(1, 1, 0, 0);
            Assert.Equal(17.00, nelu.TotalAmount());
        }

        [Fact]
        public void CustomerThatRentsOneCityBikeForMoreDaysShouldReturnCorrectTotalAmount()
        {
            Customer nelu = new Customer(5, 0, 1, 0);
            Assert.Equal(35.00, nelu.TotalAmount());
        }

        [Fact]
        public void CustomerThatRentsOneJuniorBikeAndOneSportForMoreDaysShouldReturnCorrectTotalAmount()
        {
            Customer nelu = new Customer(5, 1, 0, 1);
            Assert.Equal(115.00, nelu.TotalAmount());
        }

        [Fact]
        public void CustomerThatRentsOneBikeEachForAweekShouldReturnCorrectTotalAmount()
        {
            Customer nelu = new Customer(7, 1, 1, 1);
            Assert.Equal(182.00, nelu.TotalAmount());
        }
    }
}
