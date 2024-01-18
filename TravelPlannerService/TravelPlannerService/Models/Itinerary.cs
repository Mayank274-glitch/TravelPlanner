namespace TravelPlannerService.Models
{
    public class Itinerary
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime Date { get; set; }
        public string? City { get; set; } // Add the City property

        public ICollection<Place> Places { get; set; } = new List<Place>();
    }

    // ItineraryDto.cs
    public class ItineraryDto
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        // Add other properties as needed
        public string? City { get; set; }
    }
}
