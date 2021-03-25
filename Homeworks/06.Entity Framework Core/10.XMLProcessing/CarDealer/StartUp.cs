using CarDealer.Data;
using System;
using System.IO;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();

            ResetDatabase(db);

            //Query 1.Import Suppliers
            var inputXml = File.ReadAllText("./Datasets/suppliers.xml");
            var result = ImportSuppliers(db, inputXml);
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
            var
    }
}