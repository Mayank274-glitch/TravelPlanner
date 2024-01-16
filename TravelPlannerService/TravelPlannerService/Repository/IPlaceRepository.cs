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
    }
}
