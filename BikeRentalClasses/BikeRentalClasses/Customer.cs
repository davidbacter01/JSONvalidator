using System;
using System.Collections.Generic;
using System.Text;

namespace BikeRentalClasses
{
    public class Customer
    {
        private readonly int rentingDays;
        private readonly int sportBikes;
        private readonly int cityBikes;
        private readonly int juniorBikes;
        private readonly Bike sport;
        private readonly Bike city;
        private readonly Bike junior;
        public Customer(int rentingDays, int sportBikes, int cityBikes, int juniorBikes)
        {
            this.rentingDays = rentingDays;
            this.sportBikes = sportBikes;
            this.cityBikes = cityBikes;
            this.juniorBikes = juniorBikes;
            this.sport = new Bike("Sport");
            this.city = new Bike("City");
            this.junior = new Bike("Junior");
        }

        public double TotalAmount()
        {
            return sport.GetPriceForDays(rentingDays) * sportBikes +
                city.GetPriceForDays(rentingDays) * cityBikes +
                junior.GetPriceForDays(rentingDays) * juniorBikes;
        }
    }
}
