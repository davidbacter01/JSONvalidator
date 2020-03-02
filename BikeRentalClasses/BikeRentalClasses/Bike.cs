using System;

namespace BikeRentalClasses
{
    public class Bike
    {
        private string type;
        private double pricePerDay;
        public Bike()
        {
            this.type = "Sport";
            this.pricePerDay = 17.00;
        }

        public double GetPriceForDays(double days)
        {
            if (type == "Sport")
            {
                return pricePerDay;
            }

            return 0.00;
        }
    }
}
