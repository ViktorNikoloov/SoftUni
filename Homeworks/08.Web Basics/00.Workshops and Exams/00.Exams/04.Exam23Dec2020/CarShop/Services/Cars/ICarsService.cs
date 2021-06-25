using CarShop.ViewModels.Cars;
using System.Collections;

namespace CarShop.Services.Cars
{
    public interface ICarsService
    {
        public void Add(AddCarFormViewModel car, string ownerId);

        public bool IsMechanic(string userId);

        public IEnumerable AllCarsListing(string ownerId);

    }
}
