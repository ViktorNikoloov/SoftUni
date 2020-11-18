using System;
using Vehicles.Common;
using Vehicles.Models;

namespace Vehicles.Factory
{
    public class VehicleFactory
    {
        public VehicleFactory()
        {

        }

        public Vehicle CreatVehicle(string vehicleType, double vehicleFuelQuantity, double vehicleFuelConsumption)
        {
            Vehicle vehicle;

            if (vehicleType == "Car")
            {
                vehicle = new Car(vehicleFuelQuantity, vehicleFuelConsumption);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(vehicleFuelQuantity, vehicleFuelConsumption);
            }
            else
            {
                throw new ArgumentException(CommonMessages.InvalidVehicleMsg);
            }

            return vehicle;

        }
    }
}
