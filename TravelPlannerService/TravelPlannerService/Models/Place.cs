namespace TravelPlannerService.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GooglePlaceId { get; set; } // Unique identifier from Google Places API
        public string Address { get; set; }

        // Foreign key
        public int ItineraryId { get; set; }

        // Navigation property
        public Itinerary Itinerary { get; set; }
        // Add other properties as needed
    }

    // PlaceDto.cs
    public class PlaceDto
    {
        public string Name { get; set; }
        public string GooglePlaceId { get; set; }
        public string Address { get; set; }
        // Add other properties as needed
    }
}
