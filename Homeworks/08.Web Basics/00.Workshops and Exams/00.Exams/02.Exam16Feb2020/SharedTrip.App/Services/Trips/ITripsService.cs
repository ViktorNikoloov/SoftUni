using SharedTrip.App.ViewModels.Trips;

namespace SharedTrip.App.Services.Trips
{
    public interface ITripsService
    {
        void Add(TripsInputModel model, string userId);
    }
}
