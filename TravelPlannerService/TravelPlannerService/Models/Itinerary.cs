namespace TravelPlannerService.Models
{
    public class Itinerary
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? City { get; set; }

        public ICollection<Place> Places { get; set; } = new List<Place>();
    }


    // ItineraryDto.cs
    public class ItineraryDto
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? City { get; set; }
    }


    public class CityAndItineraryDto
    {
        public string City { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

}
