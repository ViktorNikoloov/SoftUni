using CarDealer.Data;
using CarDealer.DataTransferObjects.Input;
using CarDealer.DataTransferObjects.Input.CarInputDto;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();

            //ResetDatabase(db);

            //Query 10.Import Suppliers
            //var inputXml = File.ReadAllText("./Datasets/suppliers.xml");
            //var result = ImportSuppliers(db, inputXml);
            //Console.WriteLine(result);

            //02.Import Parts
            //var inputXml = File.ReadAllText("./Datasets/parts.xml");
            //var result = ImportParts(db, inputXml);
            //Console.WriteLine(result);

            //03. Import Cars
            //var inputXml = File.ReadAllText("./Datasets/cars.xml");
            //var result = ImportCars(db, inputXml);
            //Console.WriteLine(result);

            //04.Import Customers
            var inputXml = File.ReadAllText("./Datasets/customers.xml");
            var result = ImportCustomers(db, inputXml);
            Console.WriteLine(result);
        }

        private static void ResetDatabase(CarDealerContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");
            db.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");

        }

        //Query 01.Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            const string root = "Suppliers";

            var xmlSerializer = new XmlSerializer(typeof(SupplierInputModel[]), new XmlRootAttribute(root));

            var textRead = new StringReader(inputXml);

            var suppliersDto = xmlSerializer
                .Deserialize(textRead) as SupplierInputModel[];

            var suppliers = suppliersDto
                .Select(s => new Supplier
                {
                    Name = s.Name,
                    IsImporter = s.IsImporter,
                })
                .ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        //02.Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {

            const string root = "Parts";

            var xmlSerializer = new XmlSerializer(typeof(PartsInputModel[]), new XmlRootAttribute(root));

            var textRead = new StringReader(inputXml);

            var partsDto = xmlSerializer.Deserialize(textRead) as PartsInputModel[];

            var supliersId = context.Suppliers.Select(i => i.Id).ToList();

            var parts = partsDto
                .Where(s => supliersId.Contains(s.SupplierId))
                .Select(p => new Part
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierId = p.SupplierId
                })
                .ToList();

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        //03.Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            const string root = "Cars";

            var xmlSerializer = new XmlSerializer(typeof(CarInputModel[]), new XmlRootAttribute(root));

            var textReader = new StringReader(inputXml);

            var carsDto = xmlSerializer.Deserialize(textReader) as CarInputModel[];

            var partsId = context.Parts.Select(p => p.Id).ToList();

            var cars = new List<Car>();
            foreach (var carDto in carsDto)
            {
                var distinctedParts = carDto.Parts.Select(x => x.Id).Distinct();
                var parts = distinctedParts.Intersect(partsId);

                var car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TraveledDistance
                };

                foreach (var partId in parts)
                {
                    var partCar = new PartCar
                    {
                        PartId = partId
                    };

                    car.PartCars.Add(partCar);
                }

                cars.Add(car);

            }

            context.AddRange(cars);

            context.SaveChanges();


            return $"Successfully imported {cars.Count}";
        }

        //04.Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            const string root = "Customers";

            var serializer = new XmlSerializer(typeof(CostumersInputModel[]), new XmlRootAttribute(root));

            var textReader = new StringReader(inputXml);

            var customersDto = serializer.Deserialize(textReader) as CostumersInputModel[];

            var customers = customersDto
                .Select(c => new Customer()
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver

                })
                .ToList();

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        //05.Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            const string root = "Sales";

            var serializer = new XmlSerializer(typeof(SaleInputModel[]), new XmlRootAttribute(root));

            var textReader = new StringReader(inputXml);

            var salesDto = serializer.Deserialize(textReader) as SaleInputModel[];

            var carsId = context.Cars.Select(i => i.Id).ToList();

            var sales = salesDto
                .Where(s => carsId.Contains(s.CarId))
                .Select(s => new Sale()
                {
                    CarId = s.CarId,
                    CustomerId = s.CustomerId,
                    Discount = s.Discount
                })
                .ToList();

            return $"Successfully imported {sales.Count}";
        }

    }



}

