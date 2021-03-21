using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO.SalesDTOs;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext db = new CarDealerContext();

            //ResetDatabase(db);

            ////01.Import Suppliers
            //var inputJson = File.ReadAllText("../../../Datasets/suppliers.json");
            //var result = ImportSuppliers(db, inputJson);
            //Console.WriteLine(result);

            ////02.Import Parts
            //var inputJson = File.ReadAllText("../../../Datasets/parts.json");
            //var result = ImportParts(db, inputJson);
            //Console.WriteLine(result);

            //03.Import Cars
            var inputJson = File.ReadAllText("../../../Datasets/cars.json");
            var result = ImportParts(db, inputJson);
            Console.WriteLine(result);

            //04.Import Customers
            //var inputJson = File.ReadAllText("../../../Datasets/customers.json");
            //var result = ImportParts(db, inputJson);
            //Console.WriteLine(result);

        }

        private static void ResetDatabase(CarDealerContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");
            db.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");

        }

        //01.Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            Supplier[] jsonFile = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(jsonFile);
            context.SaveChanges();

            return $"Successfully imported {jsonFile.Length}.";
        }

        //02. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            Part[] jsonFile = JsonConvert.DeserializeObject<Part[]>(inputJson);
            var suppliersId = context
                .Suppliers
                .Select(s => s.Id);

            jsonFile = jsonFile
                .Where(p => suppliersId.Any(s => s == p.SupplierId))
                .ToArray();

            context.Parts.AddRange(jsonFile);
            context.SaveChanges();

            return $"Successfully imported {jsonFile.Length}.";
        }

        //03.Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            List<ImportCarDto> carDTOs = JsonConvert.DeserializeObject<List<ImportCarDto>>(inputJson);

            List<Car> cars = new List<Car>();
            foreach (var carDto in carDTOs)
            {
                Car car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                foreach (int partId in carDto.PartId.Distinct())
                {
                    car.PartCars.Add(new PartCar()
                    {
                        Car = car,
                        PartId = partId
                    });
                }
                cars.Add(car);

            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        //04.Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            Customer[] jsonFile = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(jsonFile);
            context.SaveChanges();

            return $"Successfully imported {jsonFile.Length}.";
        }
    }
}