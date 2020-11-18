using Vehicles.Common;
using Vehicles.Models.Contracts;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; private set; }

        public virtual double FuelConsumption { get; private set; }

        public string Drive(double distance)
        {
            double currDistance = distance * FuelConsumption;

            if (FuelQuantity < currDistance)
            {
                return string.Format(CommonMessages.NotEnoughtFuelMsg, this.GetType().Name);
            }

            FuelQuantity -= currDistance;
            return string.Format(CommonMessages.EnoughtFuelMsg, this.GetType().Name, distance);
        }

        public virtual void Refuel(double literes)
        => FuelQuantity += literes;


        public override string ToString()
        => $"{this.GetType().Name}: {FuelQuantity:F2}";
        
    }
}
