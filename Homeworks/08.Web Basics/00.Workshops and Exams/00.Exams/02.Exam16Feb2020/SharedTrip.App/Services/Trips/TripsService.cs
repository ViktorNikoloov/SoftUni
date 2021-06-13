using System;
using System.Globalization;

using SharedTrip.App.Data;
using SharedTrip.App.Models;
using SharedTrip.App.ViewModels.Trips;

namespace SharedTrip.App.Services.Trips
{
    public class TripsService : ITripsService
    {
        private readonly ShareTripDbContext db;

        public TripsService(ShareTripDbContext db)
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
    }
}               

