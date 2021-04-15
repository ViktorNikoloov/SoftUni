using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services;
using System;
using System.Text;

namespace RealEstates.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            var db = new ApplicationDbContext();
            db.Database.Migrate();

            while (true)
            {
                Console.Clear();
                System.Console.WriteLine("Choose an option:");
                System.Console.WriteLine("1. Property search");
                System.Console.WriteLine("2. Most expensive districts");
                System.Console.WriteLine("3. Average price per square meter");
                System.Console.WriteLine("0. Exit");

                bool parsed = int.TryParse(Console.ReadLine(), out int option);
                if (parsed && option == 0)
                {
                    break;
                }

                if (parsed && (option >= 1 && option <= 3))
                {
                    switch (option)
                    {
                        case 1:
                            PropertySearch(db);
                            break;
                        case 2:
                            MostExpensiveDistricts(db);
                            break;
                        case 3:
                            AveragePricePerSquareMeter(db);
                            break;
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }

        }

        private static void AveragePricePerSquareMeter(ApplicationDbContext dbContext)
        {
            IPropertiesService propertiesService = new PropertiesService(dbContext);
            Console.WriteLine($"Average price per square meter: {propertiesService.AveragePricePerSquareMeter():F2}€/m²");
             
        }


        private static void MostExpensiveDistricts(ApplicationDbContext db)
        {
            Console.Write("Districts count:");
            var count = int.Parse(Console.ReadLine());

            IDistrictsService districtsService = new DistrictService(db);

            var districts = districtsService.GetMostExpensiveDistricts(count);
            foreach (var distrct in districts)
            {
                Console.WriteLine($"{distrct.Name} => {distrct.AveragePricePerSquareMeter}€/m² ({distrct.PropertiesCount})");
            }
        }

        private static void PropertySearch(ApplicationDbContext db)
        {
            Console.Write("Min price:");
            int minPrice = int.Parse(Console.ReadLine());
            Console.Write("Max Price:");
            int maxPrice = int.Parse(Console.ReadLine());
            Console.Write("Min Size:");
            int minSize = int.Parse(Console.ReadLine());
            Console.Write("Max Size:");
            int maxSize = int.Parse(Console.ReadLine());

            IPropertiesService service = new PropertiesService(db);
            var properties = service.Search(minPrice, maxPrice, minSize, maxSize);

            foreach (var property in properties)
            {
                Console.WriteLine($"{property.DistrictName}; {property.BuildingType}; {property.PropertyType} => {property.Price}€ => {property.Size}m²");
            }
        }
    }
}
