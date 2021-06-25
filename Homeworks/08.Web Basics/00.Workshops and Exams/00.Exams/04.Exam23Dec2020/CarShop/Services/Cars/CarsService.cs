using CarShop.Data;
using CarShop.Models;
using CarShop.ViewModels.Cars;
using System.Collections;
using System.Linq;

namespace CarShop.Services.Cars
{
    public class CarsService : ICarsService
    {
        private readonly CarShopDbContext db;

        public CarsService(CarShopDbContext db)
        {
            this.db = db;
        }

        public void Add(AddCarFormViewModel car, string ownerId)
        {
            db.Add(new Car
            {
                Model = car.Model,
                Year = car.Year,
                PictureUrl = car.Image,
                PlateNumber = car.PlateNumber,
                OwnerId = ownerId,
            });

            db.SaveChanges();
        }

        public IEnumerable AllCarsListing (string userId)
        {

            var carsQuery = db.Cars.AsQueryable();

            if (IsMechanic(userId))
            {
                carsQuery = carsQuery.Where(x => x.Issues.Any(x => !x.IsFixed));
            }
            else
            {
                carsQuery = carsQuery.Where(x => x.OwnerId == userId);
            }

            var cars = carsQuery
                .Select(x => new AllCarsListingModel
                {
                    CarId = x.Id,
                    Title = x.Model,
                    PlateNumber = x.PlateNumber,
                    Image = x.PictureUrl,
                    RemainingIssues = x.Issues.Count(x => !x.IsFixed),
                    FixedIssues = x.Issues.Count(x=>x.IsFixed),
                })
                .ToList();

            return cars;
        }


        public bool IsMechanic(string userId)
        => db.Users.Any(x => x.Id == userId && x.IsMechanic);
    }
}
