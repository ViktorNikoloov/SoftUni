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
                System.Console.WriteLine("0. Exit");

                bool parsed = int.TryParse(Console.ReadLine(), out int option);
                if (parsed && option == 0)
                {
                    break;
                }

                if (parsed && (option >= 1 && option <= 2))
                {
                    switch (option)
                    {
                        case 1:
                            PropertySearch(db);
                            break;
                        case 2:
                            MostExpensiveDistricts(db);
                            break;
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }

        }

        private static void MostExpensiveDistricts(ApplicationDbContext db)
        {
            IDistrictsService districtsService;

            var districts = districtsService.GetMostExpensiveDistricts(20);
            foreach (var distrct in districts)
            {
                Console.WriteLine($"{distrct.Name} => {distrct.AveragePricePerSquareMeter}€/m² ({distrct.PropertiesCount})");
            }
        }

        private static void PropertySearch(ApplicationDbContext db)
        {
            Console.WriteLine("Min price");
            int minPrice = int.Parse(Console.ReadLine());
            Console.WriteLine("Max Price");
            int maxPrice = int.Parse(Console.ReadLine());
            Console.WriteLine("Min Size");
            int minSize = int.Parse(Console.ReadLine());
            Console.WriteLine("Max Size");
            int maxSize = int.Parse(Console.ReadLine());

            IPropertiesService service = new PropertiesService(db);
            var properties = service.Search(minPrice, maxPrice, minSize, maxSize);

            foreach (var property in properties)
            {
                Console.WriteLine($"{property.DistrictName}; {property.BuildingType}; {property.PropertyType} => {property.Price}€ => {property.Size}");
            }
        }
    }
}
