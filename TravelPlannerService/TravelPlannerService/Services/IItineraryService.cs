using TravelPlannerService.Models;

namespace TravelPlannerService.Services
{
    public interface IItineraryService
    {
        IEnumerable<Itinerary> GetAllItineraries();
        Itinerary GetItineraryById(int id);
        Itinerary CreateItinerary(ItineraryDto itineraryDto);
        Itinerary UpdateItinerary(int id, ItineraryDto itineraryDto);
        bool DeleteItinerary(int id);
        Place AddPlaceToItinerary(int itineraryId, PlaceDto placeDto);
        IEnumerable<string> GetCitiesForDate(DateTime date);
    }

}
