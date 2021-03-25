using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO.CarSalesWithDiscount;
using CarDealer.DTO.CarsListOfPartsDto;
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
            //var inputJson = File.ReadAllText("../../../Datasets/customers.json");
            //var result = ImportCustomers(db, inputJson);
            //Console.WriteLine(result);


            //05.Import Sales
            //var inputJson = File.ReadAllText("../../../Datasets/sales.json");
            //var result = ImportSales(db, inputJson);
            //Console.WriteLine(result);

            //06.Export Ordered Customers
            //var result = GetOrderedCustomers(db);
            //Console.WriteLine(result);

            //07.Export Cars from Make Toyota
            //var result = GetCarsFromMakeToyota(db);
            //Console.WriteLine(result);

            //08.Export Local Suppliers
            //var result = GetLocalSuppliers(db);
            //Console.WriteLine(result);

            //09.Export Cars with Their List of Parts
            //var result = GetCarsWithTheirListOfParts(db);
            //Console.WriteLine(result);

            //10.Export Total Sales by Customer
            //var result = GetTotalSalesByCustomer(db);
            //Console.WriteLine(result);

            //11.Export Sales with Applied Discount
            var result = GetSalesWithAppliedDiscount(db);
            Console.WriteLine(result);
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
            var sales = JsonConvert.DeserializeObject<IEnumerable<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        //06.Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var custumers = context
                .Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver/*==false*/)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            var json = JsonConvert.SerializeObject(custumers, Formatting.Indented);

            return json;
        }

        //07.Export Cars from Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        //08.Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.
                Suppliers
                .Where(s => s.IsImporter != true)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToList();

            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;
        }

        //09.Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var partsCars = context
                .Cars
                .Select(c => new CarsListDto()
                {
                    Car = new CarsWithPartsListDto()
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    Parts = c.PartCars.Select(p => new PartsList()
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price.ToString("F2")
                    }).ToList()

                })
                .ToList();

            var json = JsonConvert.SerializeObject(partsCars, Formatting.Indented);

            return json;
        }

        //10.Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            //Get all customers that have bought at least 1 car and get their names, bought cars count and total spent money on cars.
            //Order the result list by total spent money descending then by total bought cars again in descending order. 
            //Export the list of customers to JSON in the format provided below.

            var customers = context
                .Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count(),
                    spentMoney = c.Sales
                                    .Select(car => car.Car.PartCars
                                      .Select(x => x.Part)
                                         .Sum(p => p.Price))
                                            .Sum()

                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToList();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        //11.Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            //Get first 10 sales with information about the car,
            //customer and price of the sale with and without discount.
            //Export the list of sales to JSON in the format provided below.

            var sales = context
                .Cars
                .Select(c => new CarInfo()
                {
                    Car = new CarDto()
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    CustomerName = c.Sales.Select(x => x.Customer.Name).ToString(),
                    Discount = c.Sales.Select(d => d.Discount),
                    Price = c.PartCars.Select(pc => pc.Part.Price),

                })
                .ToList();

            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }
    }

}
