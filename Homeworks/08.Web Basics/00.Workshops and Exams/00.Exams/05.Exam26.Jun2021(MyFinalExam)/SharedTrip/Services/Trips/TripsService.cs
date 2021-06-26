namespace SharedTrip.Services.Trips
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Globalization;

    using SharedTrip.Data;
    using SharedTrip.Models;
    using SharedTrip.ViewModels.Trips;

    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(TripsInputModel model, string userId)
        {
            db.UserTrips.Add(new UserTrip
            {
                UserId = userId,
                Trip = new Trip
                {
                    StartPoint = model.StartPoint,
                    EndPoint = model.EndPoint,
                    DepartureTime = DateTime.ParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                    ImagePath = model.ImagePath,
                    Seats = model.Seats,
                    Description = model.Description,
                }
            });

            db.SaveChanges();
        }

        public IEnumerable<TripsAllViewModel> AllTrips()
        => db.Trips.Select(x => new TripsAllViewModel
        {
            Id = x.Id,
            StartPoint = x.StartPoint,
            EndPoint = x.EndPoint,
            DepartureTime = x.DepartureTime.ToLocalTime().ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
            Seats = x.Seats - x.UserTrips.Count,
        }).ToList();

        public void AddUserToTrip(string userId, string tripId)
        {
            var hasAvaibleSeats = HasAvaibleSeats(tripId);

            db.Add(new UserTrip
            {
                UserId = userId,
                TripId = tripId,
            });

            db.SaveChanges();
        }

        public bool HasAvaibleSeats(string tripId)
        {
            var trip = db.Trips.Where(x => x.Id == tripId)
                .Select(x => new
                {
                    x.Seats,
                    TakenSeats = x.UserTrips.Count,
                })
                .FirstOrDefault();

            var avaibleSeats = trip.Seats - trip.TakenSeats;

            return avaibleSeats <= 0;
        }

        public TripsDetailsViewModel TripDetails(string id)
        => db.Trips.Where(x => x.Id == id)
               .Select(x=> new TripsDetailsViewModel
               {
                   Id = x.Id,
                   StartPoint = x.StartPoint,
                   EndPoint = x.EndPoint,
                   DepartureTime = x.DepartureTime.ToLocalTime().ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                   AvaibleSeats = x.Seats - x.UserTrips.Count,
                   Description = x.Description,
                   ImagePath = x.ImagePath,
               })
                .FirstOrDefault();


        public bool IsUserInTrip(string userId, string tripId)
        => db.UserTrips.Any(x => x.TripId == tripId && x.UserId == userId);
    }
}
