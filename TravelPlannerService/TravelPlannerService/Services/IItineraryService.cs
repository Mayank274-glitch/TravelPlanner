using TravelPlannerService.Models;

namespace TravelPlannerService.Services
{
    public interface IItineraryService
    {
        IEnumerable<Itinerary> GetAll();
        Itinerary GetById(int id);
        void Create(Itinerary itinerary);
        void Update(Itinerary itinerary);
        void Delete(int id);
    }
}
