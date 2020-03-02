using System;
using System.Collections.Generic;
using System.Text;

namespace BikeRentalClasses
{
    public class Customer
    {
        private readonly int rentingDays;
        private readonly Bike sport;
        public Customer(int rentingDays)
        {
            this.rentingDays = rentingDays;
            this.sport = new Bike("Sport");
        }

        public double TotalAmount()
        {
            return sport.GetPriceForDays(rentingDays);
        }
    }
}
