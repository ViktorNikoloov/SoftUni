namespace SharedTrip.Services.Trips
{
    using System.Collections.Generic;

    using SharedTrip.Models;
    using SharedTrip.ViewModels.Trips;

    public interface ITripsService
    {
        void Add(TripsInputModel model, string userId);

        IEnumerable<TripsAllViewModel> AllTrips();

        TripsDetailsViewModel TripDetails(string id);

        bool HasAvaibleSeats(string tripId);

        bool IsUserInTrip(string userId, string tripId);

        void AddUserToTrip(string userId, string tripId);
    }
}
