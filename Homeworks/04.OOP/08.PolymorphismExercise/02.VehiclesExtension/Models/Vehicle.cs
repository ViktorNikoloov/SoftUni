using System;
using Vehicles.Common;
using Vehicles.Models.Contracts;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }
            set
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }


            }
        }

        public virtual double FuelConsumption { get; private set; }

        public double TankCapacity { get; private set; }

        public virtual bool IsEmpty { get; set; }

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
        {
            if (literes <= 0)
            {
                throw new InvalidOperationException(CommonMessages.NegativeAmountOfFuel);
            }
            else if (fuelQuantity + literes > TankCapacity)
            {
                throw new InvalidOperationException(string.Format(CommonMessages.FullTankCapacity, literes));
            }

            IsEmpty = false;

            FuelQuantity += literes;
        }


        public override string ToString()
        => $"{this.GetType().Name}: {FuelQuantity:F2}";

    }
}
