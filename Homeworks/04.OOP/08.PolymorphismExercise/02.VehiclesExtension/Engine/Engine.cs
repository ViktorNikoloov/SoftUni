using System;
using Vehicles.Factories;
using Vehicles.IO.Contracts;
using Vehicles.Models;

namespace Vehicles
{
    public class Engine : IEngine
    {
        IReader reader;
        IWriter writer;

        private readonly VehicleFactory vehicleFactory;

        private Engine()
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
            try
            {
                Vehicle car = SettingVehicleType();

                Vehicle truck = SettingVehicleType();

                Vehicle bus = SettingVehicleType();

                int n = int.Parse(reader.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    string[] cmdArgs = reader.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string action = cmdArgs[0];
                    string vecihleType = cmdArgs[1];
                    double amount = double.Parse(cmdArgs[2]);

                    try
                    {
                        if (vecihleType == "Car")
                        {
                            DoTheAction(car, action, vecihleType, amount);
                        }
                        else if (vecihleType == "Truck")
                        {
                            DoTheAction(truck, action, vecihleType, amount);
                        }
                        else
                        {
                            DoTheAction(bus, action, vecihleType, amount);
                        }

                    }
                    catch (InvalidOperationException ioe)
                    {
                        Console.WriteLine(ioe.Message);
                    }

                }

                writer.WriteLine(car.ToString());
                writer.WriteLine(truck.ToString());
                writer.WriteLine(bus.ToString());

            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }

        }

        private static void DoTheAction(Vehicle vehicle, string action, string vecihleType, double amount)
        {
            if (action == "DriveEmpty")
            {
                vehicle.IsEmpty = true;
                Console.WriteLine(vehicle.Drive(amount));
            }
            else if (action == "Drive")
            {
                Console.WriteLine(vehicle.Drive(amount));
            }
            else
            {
                vehicle.Refuel(amount);
            }
        }

        public Vehicle SettingVehicleType()
        {
            string[] vehicleArgs = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string vehicleType = vehicleArgs[0];
            double vehicleFuelQuantity = double.Parse(vehicleArgs[1]);
            double vehicleFuelConsumption = double.Parse(vehicleArgs[2]);
            double vehicleTankCapacity = double.Parse(vehicleArgs[3]);

            Vehicle currVehicle = vehicleFactory.CreatVehicle(vehicleType, vehicleFuelQuantity, vehicleFuelConsumption, vehicleTankCapacity);

            return currVehicle;

        }
    }
}
