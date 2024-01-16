namespace TravelPlannerService.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GooglePlaceId { get; set; } // Unique identifier from Google Places API
        public string Address { get; set; }
        // Add other properties as needed
    }
}
