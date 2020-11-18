using Vehicles.Models.Contracts;

namespace Vehicles.Models
{
    public class Truck : Vehicle, ITruck
    {
        private const double TRUCK_AC_INCREASING = 1.6;
        private const double TRUCK_FUEL_TANK_LEAK = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {

        }

        public override double FuelConsumption 
        => base.FuelConsumption + TRUCK_AC_INCREASING;

        public override void Refuel(double literes)
        => base.Refuel(literes * TRUCK_FUEL_TANK_LEAK);
        

        public override string ToString()
        => base.ToString();
        
    }
}
