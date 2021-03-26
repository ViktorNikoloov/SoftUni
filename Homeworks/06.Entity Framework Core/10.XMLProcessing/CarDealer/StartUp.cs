using CarDealer.Data;
using CarDealer.DataTransferObjects.Input;
using CarDealer.Models;
using System;
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
            var inputXml = File.ReadAllText("./Datasets/parts.xml");
            var result = ImportParts(db, inputXml);
            Console.WriteLine(result);


        }

        private static void ResetDatabase(CarDealerContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");
            db.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");

        }

        //Query 1.Import Suppliers
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
    }



}

