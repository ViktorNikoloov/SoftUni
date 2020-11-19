using System;
using Vehicles.Common;
using Vehicles.Models;

namespace Vehicles.Factories
{
    public class VehicleFactory
    {
        public VehicleFactory()
        {

        }

        public Vehicle CreatVehicle(string vehicleType, double vehicleFuelQuantity, double vehicleFuelConsumption, double vehicleTankCapacity)
        {
            Vehicle vehicle;

            if (vehicleType == "Car")
            {
                vehicle = new Car(vehicleFuelQuantity, vehicleFuelConsumption, vehicleTankCapacity);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(vehicleFuelQuantity, vehicleFuelConsumption, vehicleTankCapacity);
            }
            else if (vehicleType == "Bus")
            {
                vehicle = new Bus(vehicleFuelQuantity, vehicleFuelConsumption, vehicleTankCapacity);
            }
            else
            {
                throw new ArgumentException(CommonMessages.InvalidVehicleMsg);
            }

            return vehicle;

        }
    }
}
