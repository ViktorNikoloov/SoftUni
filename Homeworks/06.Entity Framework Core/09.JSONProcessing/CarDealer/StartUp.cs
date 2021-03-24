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
        static IMapper mapper;

        public static void Main(string[] args)
        {
            CarDealerContext db = new CarDealerContext();

            InitializeStaticMapper();
            //ResetDatabase(db);

            //01.Import Suppliers
            //var inputJson = File.ReadAllText("../../../Datasets/suppliers.json");
            //var result = ImportSuppliers(db, inputJson);
            //Console.WriteLine(result);

            //02.Import Parts
            //var inputJson = File.ReadAllText("../../../Datasets/parts.json");
            //var result = ImportParts(db, inputJson);
            //Console.WriteLine(result);

            //03.Import Cars
            //var inputJson = File.ReadAllText("../../../Datasets/cars.json");
            //var result = ImportCars(db, inputJson);
            //Console.WriteLine(result);

            //04.Import Customers
            var inputJson = File.ReadAllText("../../../Datasets/customers.json");
            var result = ImportCustomers(db, inputJson);
            Console.WriteLine(result);


            //05.Import Sales
            //var inputJson = File.ReadAllText("../../../Datasets/sales.json");
            //var result = ImportSales(db, inputJson);
            //Console.WriteLine(result);


        }

        /*We can use it for export*/
        private static void InitializeStaticMapper()
        {
            /*Static Mapper*/
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });
        }

        /*We need to use it for import*/
        private static void InitializeInstanceMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }

        /*Delete old DB and create new one*/
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
            var jsonFile = JsonConvert.DeserializeObject<IEnumerable<Supplier>>(inputJson);

            context.Suppliers.AddRange(jsonFile);
            context.SaveChanges();

            return $"Successfully imported {jsonFile.Count()}.";
        }

        //02. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<IEnumerable<Part>>(inputJson);

            var supplierIds = context.Suppliers.Select(x => x.Id).ToList();

            var partsToImport = parts.Where(p => supplierIds.Any(s => s == p.SupplierId)).ToList();

            context.Parts.AddRange(partsToImport);
            context.SaveChanges();

            return $"Successfully imported {partsToImport.Count()}.";
        }

        //03.Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<IEnumerable<ImportCarDto>>(inputJson);

            var cars = new List<Car>();
            foreach (var carDto in carsDto)
            {
                var car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance,
                };

                foreach (var partId in carDto.PartsId.Distinct())
                {
                    car.PartCars.Add(new PartCar()
                    {
                        Car = car,
                        PartId = partId
                    });
                }

                cars.Add(car);
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        //04.Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            //var customers = JsonConvert.DeserializeObject <IEnumerable<Customer>>(inputJson);

            //context.Customers.AddRange(customers);
            //context.SaveChanges();

            //return $"Successfully imported {customers.Count()}.";

            /*Mapper Solution*/
            InitializeInstanceMapper();

            var customersDto = JsonConvert.DeserializeObject<IEnumerable<ImportCustomersDto>>(inputJson);

            var customers = mapper.Map<IEnumerable<Customer>>(customersDto);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        //05.Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject <IEnumerable<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

    }

}
