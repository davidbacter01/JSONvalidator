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
        private readonly Bike sport;
        private readonly Bike city;
        public Customer(int rentingDays, int sportBikes, int cityBikes)
        {
            this.rentingDays = rentingDays;
            this.sportBikes = sportBikes;
            this.cityBikes = cityBikes;
            this.sport = new Bike("Sport");
            this.city = new Bike("City");
        }

        public double TotalAmount()
        {
            return sport.GetPriceForDays(rentingDays)*sportBikes+city.GetPriceForDays(rentingDays)*cityBikes;
        }
    }
}
