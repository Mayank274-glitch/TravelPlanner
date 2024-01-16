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
    }
}
