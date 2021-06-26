namespace SharedTrip.Controllers
{
    using System;
    using System.Globalization;

    using MyWebServer.Controllers;
    using MyWebServer.Http;

    using SharedTrip.Services.Trips;
    using SharedTrip.ViewModels.Trips;

    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse All()
        {
            if (!User.IsAuthenticated)
            {
                //return Redirect("/Users/Login");

                return Error($"401 Unauthorized"); // This way is more ser-friendly
            }

            var viewModel = tripsService.AllTrips();

            return View(viewModel);
        }

        public HttpResponse Add()
        {
            if (!User.IsAuthenticated)
            {
                //return Redirect("/Users/Login");

                return Error($"401 Unauthorized"); // This way is more ser-friendly
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Add(TripsInputModel model)
        {
            if (!User.IsAuthenticated)
            {
                //return Redirect("/Users/Login");

                return Error($"401 Unauthorized"); // This way is more ser-friendly
            }

            bool isParsed = DateTime.TryParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
            var userId = User.Id;

            if (string.IsNullOrWhiteSpace(model.StartPoint))
            {
                //return Redirect("/Trips/Add");
                return Error("Start point is required"); // This way is more ser-friendly
            }

            if (string.IsNullOrWhiteSpace(model.EndPoint))
            {
                //return Redirect("/Trips/Add");
                return Error("End point is required");
            }

            if (2 > model.Seats || model.Seats > 6)
            {
                //return Redirect("/Trips/Add");
                return Error("Seat should be between 2 and 6");
            }

            if (string.IsNullOrWhiteSpace(model.Description) || model.Description.Length > 80)
            {
                //return Redirect("/Trips/Add");
                return Error("Description is required and has max length of 80");
            }

            if (!isParsed)
            {
                //return Redirect("/Trips/Add");
                return Error("Invalid Departure time. Please use this format (dd.MM.yyyy HH: mm)");
            }

            tripsService.Add(model, userId);

            return Redirect("/");
        }

        public HttpResponse Details(string tripId)
        {
            if (!User.IsAuthenticated)
            {
                //return Redirect("/Users/Login");

                return Error($"401 Unauthorized"); // This way is more ser-friendly
            }

            var tripView = tripsService.TripDetails(tripId);

            return View(tripView);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!User.IsAuthenticated)
            {
                //return Redirect("/Users/Login");

                return Error($"401 Unauthorized"); // This way is more ser-friendly
            }

            var userId = User.Id;
            if (tripsService.IsUserInTrip(userId, tripId))
            {
                return Redirect($"/Trips/Details?tripId={tripId}");
            }

            if (tripsService.HasAvaibleSeats(tripId))
            {
                return Error("No seats avaible.");
            }

            tripsService.AddUserToTrip(userId, tripId);

            return Redirect("/Trips/All");
        }
    }
}
