using TravelPlannerService.Models;

namespace TravelPlannerService.Repository
{
    public interface IPlaceRepository
    {
        IEnumerable<Place> GetAll();
        Place GetById(int id);
        void Add(Place place);
        void Update(Place place);
        void Delete(int id);

        // New method for getting all places for a specific itinerary
        IEnumerable<Place> GetPlacesByItineraryId(int itineraryId);
    }
}
