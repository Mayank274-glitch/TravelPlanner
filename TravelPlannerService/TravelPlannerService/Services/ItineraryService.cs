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

        public IEnumerable<Itinerary> GetAll()
        {
            return _itineraryRepository.GetAll();
        }

        public Itinerary GetById(int id)
        {
            return _itineraryRepository.GetById(id);
        }

        public void Create(Itinerary itinerary)
        {
            _itineraryRepository.Add(itinerary);
        }

        public void Update(Itinerary itinerary)
        {
            _itineraryRepository.Update(itinerary);
        }

        public void Delete(int id)
        {
            _itineraryRepository.Delete(id);
        }
    }
}
