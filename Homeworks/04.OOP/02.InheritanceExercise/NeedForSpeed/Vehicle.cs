using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public abstract class Vehicle
    {

        private const double DefaultFuelConsumption = 1.25;

        public Vehicle(int horesePower, double fuel)
        {
            HoresePower = horesePower;
            Fuel = fuel;
        }

        public virtual double FuelConsumption 
            => DefaultFuelConsumption;

        public int HoresePower { get; set; }

        public double Fuel { get; set; }

        public virtual void Drive(double kilometers)
        {
            Fuel -= kilometers * FuelConsumption;
        }

    }
}
