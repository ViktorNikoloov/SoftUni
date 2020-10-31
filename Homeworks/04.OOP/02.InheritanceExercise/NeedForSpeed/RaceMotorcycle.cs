using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double DefaultFuelConsumption = 8;

        public RaceMotorcycle(int horesePower, double fuel) 
            : base(horesePower, fuel)
        {

        }

        public override double FuelConsumption 
            => DefaultFuelConsumption;
    }
}
