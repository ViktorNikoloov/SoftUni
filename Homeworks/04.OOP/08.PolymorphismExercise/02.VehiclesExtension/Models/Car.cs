
using Vehicles.Models.Contracts;

namespace Vehicles.Models
{
    public class Car : Vehicle, ICar
    {
        private const double CAR_AC_INCREASING = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override double FuelConsumption 
        => base.FuelConsumption + CAR_AC_INCREASING; 

        public override void Refuel(double literes)
        => base.Refuel(literes);
        
        public override string ToString()
         => base.ToString();
        
    }
}
