using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BikeRentalClasses.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void CustomerThatRentsOneBikeForADayShouldReturnCorrectTotalAmount()
        {
            Customer nelu = new Customer(1);
            Assert.Equal(17.00, nelu.TotalAmount());
        }
    }
}
