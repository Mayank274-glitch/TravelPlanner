using TravelPlannerService.Models;

namespace TravelPlannerService.Repository
{
    public interface IItineraryRepository
    {
        IEnumerable<Itinerary> GetAll();
        Itinerary GetById(int id);
        void Add(Itinerary itinerary);
        void Update(Itinerary itinerary);
        void Delete(int id);

        // New method for adding a place to an itinerary
        void AddPlaceToItinerary(int itineraryId, Place place);

        // New method for fetching places for a specific date
        IEnumerable<Place> GetPlacesForDate(DateTime date);
    }
}
