using Microsoft.EntityFrameworkCore;
using System;
using TravelPlannerService.DbContextCreate;
using TravelPlannerService.Models;

namespace TravelPlannerService.Repository
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly AppDbContext _dbContext;

        public PlaceRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Place> GetAll()
        {
            return _dbContext.Places.ToList();
        }

        public Place GetById(int id)
        {
            return _dbContext.Places.Find(id);
        }

        public void Add(Place place)
        {
            _dbContext.Places.Add(place);
            _dbContext.SaveChanges();
        }

        public void Update(Place place)
        {
            _dbContext.Entry(place).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var place = _dbContext.Places.Find(id);
            if (place != null)
            {
                _dbContext.Places.Remove(place);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Place> GetPlacesByItineraryId(int itineraryId)
        {
            return _dbContext.Places.Where(p => p.ItineraryId == itineraryId).ToList();
        }
    }
}
