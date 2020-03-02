using System;

namespace BikeRentalClasses
{
    public class Bike
    {
        private string type;
        private double pricePerDay;
        private double pricePerWeek;
        public Bike(string type)
        {
            this.type = type;
            switch (type)
            {
                case "Sport":
                    pricePerDay = 17.00;
                    pricePerWeek = 105.00;
                    break;
                case "City":
                    pricePerDay = 7.00;
                    pricePerWeek = 42.00;
                    break;
                default:
                    pricePerDay = 0.00;
                    pricePerWeek = 0.00;
                    break;
            }
            
        }

        public double GetPriceForDays(double days)
        {
            if (days == 7)
            {
                return pricePerWeek;
            }

            return pricePerDay * days;
        }
    }
}
