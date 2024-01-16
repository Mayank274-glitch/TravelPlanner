using TravelPlannerService.Models;

namespace TravelPlannerService.Services
{
    public interface IPlaceService
    {
        IEnumerable<Place> GetAll();
        Place GetById(int id);
        void Create(Place place);
        void Update(Place place);
        void Delete(int id);
    }
}
