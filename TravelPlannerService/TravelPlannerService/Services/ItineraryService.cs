using TravelPlannerService.Models;
using TravelPlannerService.Repository;

namespace TravelPlannerService.Services
{
    public class ItineraryService : IItineraryService
    {
        private readonly IItineraryRepository _itineraryRepository;

        public ItineraryService(IItineraryRepository itineraryRepository)
        {
            _itineraryRepository = itineraryRepository;
        }

        public IEnumerable<Itinerary> GetAllItineraries()
        {
            return _itineraryRepository.GetAll();
        }

        public Itinerary GetItineraryById(int id)
        {
            return _itineraryRepository.GetById(id);
        }

        public Itinerary CreateItinerary(ItineraryDto itineraryDto)
        {
            var itinerary = new Itinerary
            {
                // Map properties from DTO to Itinerary
                Title = itineraryDto.Title,
                Date = itineraryDto.Date
                // Add other properties as needed
            };

            _itineraryRepository.Add(itinerary);
            return itinerary;
        }

        public Itinerary UpdateItinerary(int id, ItineraryDto itineraryDto)
        {
            var existingItinerary = _itineraryRepository.GetById(id);

            if (existingItinerary != null)
            {
                // Map properties from DTO to existing Itinerary
                existingItinerary.Title = itineraryDto.Title;
                existingItinerary.Date = itineraryDto.Date;
                // Update other properties as needed

                _itineraryRepository.Update(existingItinerary);
            }

            return existingItinerary;
        }

        public bool DeleteItinerary(int id)
        {
            var existingItinerary = _itineraryRepository.GetById(id);

            if (existingItinerary != null)
            {
                _itineraryRepository.Delete(id);
                return true;
            }

            return false;
        }

        public Place AddPlaceToItinerary(int itineraryId, PlaceDto placeDto)
        {
            var itinerary = _itineraryRepository.GetById(itineraryId);

            if (itinerary != null)
            {
                var place = new Place
                {
                    // Map properties from DTO to Place
                    Name = placeDto.Name,
                    GooglePlaceId = placeDto.GooglePlaceId,
                    Address = placeDto.Address
                    // Add other properties as needed
                };

                _itineraryRepository.AddPlaceToItinerary(itineraryId, place);
                return place;
            }

            return null;
        }

        public IEnumerable<string> GetCitiesForDate(DateTime date)
        {
            // Retrieve places for the given date from the repository
            var placesForDate = _itineraryRepository.GetPlacesForDate(date);

            // Extract distinct cities from the retrieved places' associated itineraries
            var cities = placesForDate
                .Where(place => place.Itinerary != null)
                .Select(place => place.Itinerary.City)
                .Distinct();

            return cities;
        }
    }
}
