using System.Collections.Generic;
using SharedTrip.App.Models;
using SharedTrip.App.ViewModels.Trips;

namespace SharedTrip.App.Services.Trips
{
    public interface ITripsService
    {
        void Add(TripsInputModel model, string userId);

        IEnumerable<TripsAllViewModel> AllTrips();

        Trip TripDetails(string id);

        bool HasAvaibleSeats(string tripId);

        bool IsUserInTrip(string userId, string tripId);

        void AddUserToTrip(string userId, string tripId);
    }
}
