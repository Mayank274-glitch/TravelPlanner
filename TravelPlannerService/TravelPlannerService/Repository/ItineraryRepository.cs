using Microsoft.EntityFrameworkCore;
using System;
using TravelPlannerService.DbContextCreate;
using TravelPlannerService.Models;

namespace TravelPlannerService.Repository
{
    public class ItineraryRepository : IItineraryRepository
    {
        private readonly AppDbContext _dbContext;

        public ItineraryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Itinerary> GetAll()
        {
            return _dbContext.Itineraries.ToList();
        }

        public Itinerary GetById(int id)
        {
            return _dbContext.Itineraries.Find(id);
        }

        public void Add(Itinerary itinerary)
        {
            _dbContext.Itineraries.Add(itinerary);
            _dbContext.SaveChanges();
        }

        public void Update(Itinerary itinerary)
        {
            _dbContext.Entry(itinerary).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var itinerary = _dbContext.Itineraries.Find(id);
            if (itinerary != null)
            {
                _dbContext.Itineraries.Remove(itinerary);
                _dbContext.SaveChanges();
            }
        }

        public void AddPlaceToItinerary(int itineraryId, Place place)
        {
            var itinerary = GetById(itineraryId);
            if (itinerary != null)
            {
                itinerary.Places.Add(place);
                Update(itinerary);
            }
        }

        public IEnumerable<Place> GetPlacesForDate(DateTime date)
        {
            // Implementation to fetch places for a specific date from your database
            // Use LINQ or any other method based on your database structure

            // Example using LINQ:
            var places = _dbContext.Places
                .Where(place => place.Itinerary.Date == date)
                .ToList();

            return places;
        }
    }
}
