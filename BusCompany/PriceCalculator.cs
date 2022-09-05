using System;

namespace BusCompany
{
    public class PriceCalculator
    {
        int initialFee = 2500;
        int d1KmFee = 10;
        int d2KmFee = 8;
        int d3KmFee = 6;
        decimal initialFeeFactor = 1;
        decimal kmFeeFactor = 1;

        public decimal CalculatePrice(int distance, BusType busType)
        {
            int d1 = 0, d2 = 0, d3 = 0;

            if (distance < 0)
                throw new ArgumentException("Distance cannot be negative!");

            switch (busType)
            {
                case BusType.Mini:
                    initialFeeFactor = 0.8m;
                    kmFeeFactor = 0.6m;
                    break;
                case BusType.Luxory:
                    initialFeeFactor = 1.3m;
                    kmFeeFactor = 1.5m;
                    break;
            }

            if (distance < 100)
                d1 = distance;
            else if (distance <= 500)
            {
                d1 = 99;
                d2 = distance - 99;
            }
            else{
                d1 = 99;
                d2 = 401;
                d3 = distance - 500;
            }

            decimal price = initialFeeFactor * initialFee +
                kmFeeFactor * (d1KmFee * d1 + d2KmFee * d2 + d3KmFee * d3);

            return price;
        }

    }

    // BusType enumeration
    public enum BusType
    {
        Standard,
        Luxory,
        Mini
    };

}
