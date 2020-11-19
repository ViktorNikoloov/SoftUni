using Vehicles.Models.Contracts;

namespace Vehicles.Models
{
    public class Bus : Vehicle, IBus
    {
        private const double BUS_AC_INCREASING = 1.4;

        
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            :  base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            
        }

        public override bool IsEmpty { get; set; }
        
        public override double FuelConsumption
        {
            get
            {
                if (!IsEmpty)
                {
                    return base.FuelConsumption + BUS_AC_INCREASING;
                }

                return base.FuelConsumption;
            }
        }

        public override void Refuel(double literes)
        {
            base.Refuel(literes);
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
