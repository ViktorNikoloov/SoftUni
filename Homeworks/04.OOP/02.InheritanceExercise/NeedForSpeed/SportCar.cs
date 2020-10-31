using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double DefaultFuelConsumption = 10;

        public SportCar(int horesePower, double fuel) : base(horesePower, fuel)
        {

        }

        public override double FuelConsumption 
            => DefaultFuelConsumption;
    }
}
