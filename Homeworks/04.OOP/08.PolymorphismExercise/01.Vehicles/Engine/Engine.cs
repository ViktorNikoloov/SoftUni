using System;
using Vehicles.Factory;
using Vehicles.IO.Contracts;
using Vehicles.Models;

namespace Vehicles
{
    public class Engine : IEngine
    {
        IReader reader;
        IWriter writer;

        private readonly VehicleFactory vehicleFactory;

        private  Engine()
        {
            vehicleFactory = new VehicleFactory();
        }

        public Engine(IReader reader, IWriter Writer)
            : this()
        {
            this.reader = reader;
            this.writer = Writer;
        }

        public void Run()
        {
            Vehicle car = SettingVehicleType();

            Vehicle truck = SettingVehicleType();

            int n = int.Parse(reader.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = cmdArgs[0];
                string vecihleType = cmdArgs[1];
                double amount = double.Parse(cmdArgs[2]);

                if (action == "Drive")
                {
                    if (vecihleType == "Car")
                    {
                        Console.WriteLine(car.Drive(amount));
                    }
                    else
                    {
                        Console.WriteLine(truck.Drive(amount));
                    }
                }
                else
                {
                    if (vecihleType == "Car")
                    {
                        car.Refuel(amount);
                    }
                    else
                    {
                        truck.Refuel(amount);
                    }
                }

            }

            writer.WriteLine(car.ToString());
            writer.WriteLine(truck.ToString());

        }

        public Vehicle SettingVehicleType()
        {
            string[] vehicleArgs = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string vehicleType = vehicleArgs[0];
            double vehicleFuelQuantity = double.Parse(vehicleArgs[1]);
            double vehicleFuelConsumption = double.Parse(vehicleArgs[2]);

            Vehicle currVehicle = vehicleFactory.CreatVehicle(vehicleType, vehicleFuelQuantity, vehicleFuelConsumption);

            return currVehicle;

        }
    }
}
