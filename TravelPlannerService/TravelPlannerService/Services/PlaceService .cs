using TravelPlannerService.Models;
using TravelPlannerService.Repository;

namespace TravelPlannerService.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;

        public PlaceService(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public IEnumerable<Place> GetAll()
        {
            return _placeRepository.GetAll();
        }

        public Place GetById(int id)
        {
            return _placeRepository.GetById(id);
        }

        public void Create(Place place)
        {
            _placeRepository.Add(place);
        }

        public void Update(Place place)
        {
            _placeRepository.Update(place);
        }

        public void Delete(int id)
        {
            _placeRepository.Delete(id);
        }
    }
}
