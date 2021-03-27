using CarDealer.Data;
using CarDealer.DataTransferObjects.Input;
using CarDealer.DataTransferObjects.Input.CarInputDto;
using CarDealer.DataTransferObjects.Output;
using CarDealer.DataTransferObjects.Output.GetCarsWithTheirListOfParts;
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
            //var inputXml = File.ReadAllText("./Datasets/customers.xml");
            //var result = ImportCustomers(db, inputXml);
            //Console.WriteLine(result);

            //06.Cars With Distance
            //var result = GetCarsWithDistance(db);
            //Console.WriteLine(result);

            //07.Export Cars From Make BMW 
            //var result = GetCarsFromMakeBmw(db);
            //Console.WriteLine(result);

            //08.Local Suppliers
            //var result = GetCarsWithTheirListOfParts(db);
            //Console.WriteLine(result);

            //10.Total Sales by Customer
            //var result = GetTotalSalesByCustomer(db);
            //Console.WriteLine(result);

            //11.Sales with Applied Discount
            var result = GetSalesWithAppliedDiscount(db);
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

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        //06.Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            //Get all cars with distance more than 2,000,000.
            //Order them by make, then by model alphabetically. Take top 10 records.

            var cars = context
                .Cars
                .Where(c => c.TravelledDistance > 2000000)
                .Select(c => new CarDistanceModel()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarDistanceModel[]), new XmlRootAttribute("cars"));

            var textWriter = new StringWriter();

            var nameSpace = new XmlSerializerNamespaces();
            nameSpace.Add("", "");

            xmlSerializer.Serialize(textWriter, cars, nameSpace);

            var result = textWriter.ToString().TrimEnd();

            return result;
        }

        //07.Export Cars From Make BMW 
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            //Get all cars from make BMW and
            //Order them by model alphabetically and by travelled distance descending.

            var cars = context
                .Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new CarByMakeModel()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarByMakeModel[]), new XmlRootAttribute("cars"));

            var textWriter = new StringWriter();

            var nameSpace = new XmlSerializerNamespaces();
            nameSpace.Add("", "");

            xmlSerializer.Serialize(textWriter, cars, nameSpace);

            var result = textWriter.ToString();

            return result;

        }

        //08.Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            //Get all suppliers that do not import parts from abroad.
            //Get their id, name and the number of parts they can offer to supply. 

            var suppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new CarLocalSuppliers()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarLocalSuppliers[]), new XmlRootAttribute("suppliers"));

            var textWriter = new StringWriter();

            var nameSpace = new XmlSerializerNamespaces();
            nameSpace.Add("", "");

            xmlSerializer.Serialize(textWriter, suppliers, nameSpace);

            var result = textWriter.ToString();

            return result;

        }

        //09.Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Select(c => new CarsWithPartsModel()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(pc => new PartDTO()
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .OrderByDescending(x => x.Price)
                    .ToArray()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarsWithPartsModel[]), new XmlRootAttribute("cars"));

            var textWriter = new StringWriter();

            var nameSpace = new XmlSerializerNamespaces();
            nameSpace.Add("", "");

            xmlSerializer.Serialize(textWriter, cars, nameSpace);

            var result = textWriter.ToString();

            return result;

        }

        //10.Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context
                .Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new CustomerTotalSalesModel()
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count(),
                    SpentMoney = c.Sales.Sum(x => x.Car.PartCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomerTotalSalesModel[]), new XmlRootAttribute("customers"));

            var textWriter = new StringWriter();

            var nameSpace = new XmlSerializerNamespaces();
            nameSpace.Add("", "");

            xmlSerializer.Serialize(textWriter, customers, nameSpace);

            var result = textWriter.ToString();

            return result;
        }

        //11.Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            //Get all sales with information about the car, customer and price of the sale with and without discount.

        }
    }
}

