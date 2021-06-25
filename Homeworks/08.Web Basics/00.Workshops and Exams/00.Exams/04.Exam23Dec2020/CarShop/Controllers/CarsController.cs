using CarShop.Services.Cars;
using CarShop.Services.Validator;
using CarShop.ViewModels.Cars;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Linq;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IValidator validator;
        private readonly ICarsService carsService;

        public CarsController(
            IValidator validator,
            ICarsService carsService)
        {
            this.validator = validator;
            this.carsService = carsService;
        }

        public HttpResponse Add()
        {
            if (!User.IsAuthenticated)
            {
                return Error($"401 Unauthorized");
            }

            if (!carsService.IsMechanic(User.Id))
            {
                return Error("Mechanics cannot add cars.");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Add(AddCarFormViewModel car)
        {
            if (!User.IsAuthenticated)
            {
                return Error($"401 Unauthorized");
            }

            var modelErrors = this.validator.ValidateCar(car);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            carsService.Add(car, User.Id);

            return Redirect("Cars/All");
        }

        public HttpResponse All()
        {
            if (!User.IsAuthenticated)
            {
                return Error($"401 Unauthorized");
            }

            var cars = carsService.AllCarsListing(User.Id);

            return View(cars);
        }
    }
}
