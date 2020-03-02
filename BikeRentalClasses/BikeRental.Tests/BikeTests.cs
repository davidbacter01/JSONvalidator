using System;
using BikeRentalClasses;
using Xunit;

namespace BikeRentelClasses.Tests
{
    public class BikeTests
    {
        [Fact]
        public void CheckingPriceForSportBikeForADayShouldReturnExpectedValue()
        {
            Bike sportBike = new Bike("Sport");
            Assert.Equal(17.00, sportBike.GetPriceForDays(1));
        }

        [Fact]
        public void CheckingPriceForSportBikeForAWeekShouldReturnExpectedValue()
        {
            Bike sportBike = new Bike("Sport");
            Assert.Equal(105.00, sportBike.GetPriceForDays(7));
        }

        [Fact]
        public void CheckingPricePerDayForCityBikeShouldReturnExpected()
        {
            Bike cityBike = new Bike("City");
            Assert.Equal(7.00, cityBike.GetPriceForDays(1));
        }

        [Fact]
        public void CheckingPricePerDayForJuniorBikeShouldReturnExpected()
        {
            Bike cityBike = new Bike("Junior");
            Assert.Equal(6.00, cityBike.GetPriceForDays(1));
        }
    }
}
