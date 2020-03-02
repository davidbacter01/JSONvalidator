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
                if (days == 7)
                {
                    return 105.00;
                }

                return pricePerDay * days;
            }

            return 0.00;
        }
    }
}
