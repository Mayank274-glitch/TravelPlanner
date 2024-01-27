using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelPlannerService.Models;
using TravelPlannerService.Services;

namespace TravelPlannerService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItineraryController : ControllerBase
    {
        private readonly IItineraryService _itineraryService;
        private readonly IPlaceService _placeService;

        public ItineraryController(IItineraryService itineraryService, IPlaceService placeService)
        {
            _itineraryService = itineraryService;
            _placeService = placeService;
        }

        [HttpGet]
        public IActionResult GetAllItineraries()
        {
            var itineraries = _itineraryService.GetAllItineraries();
            return Ok(itineraries);
        }

        [HttpGet("{id}")]
        public IActionResult GetItineraryById(int id)
        {
            var itinerary = _itineraryService.GetItineraryById(id);

            if (itinerary == null)
            {
                return NotFound();
            }

            return Ok(itinerary);
        }

        [HttpPost]
        public IActionResult CreateItinerary([FromBody] ItineraryDto itineraryDto)
        {
            var createdItinerary = _itineraryService.CreateItinerary(itineraryDto);

            return CreatedAtAction(nameof(GetItineraryById), new { id = createdItinerary.Id }, createdItinerary);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItinerary(int id, [FromBody] ItineraryDto itineraryDto)
        {
            var updatedItinerary = _itineraryService.UpdateItinerary(id, itineraryDto);

            if (updatedItinerary == null)
            {
                return NotFound();
            }

            return Ok(updatedItinerary);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItinerary(int id)
        {
            var result = _itineraryService.DeleteItinerary(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // New endpoint for adding a place to an itinerary
        [HttpPost("{itineraryId}/places")]
        public IActionResult AddPlaceToItinerary(int itineraryId, [FromBody] PlaceDto placeDto)
        {
            var addedPlace = _itineraryService.AddPlaceToItinerary(itineraryId, placeDto);

            if (addedPlace == null)
            {
                return NotFound();
            }

            // Retrieve the added place using the PlaceService
            var retrievedPlace = _placeService.GetById(addedPlace.Id);

            if (retrievedPlace == null)
            {
                return NotFound(); // Handle case where retrieval fails
            }

            return CreatedAtAction(nameof(PlacesController.GetById), new { id = retrievedPlace.Id }, retrievedPlace);

        }

        // ItineraryController.cs

        [HttpGet("cities")]
        public IActionResult GetCitiesForDate(DateTime startDate, DateTime endDate)
        {
            var cities = _itineraryService.GetCitiesForDate(startDate, endDate);

            if (cities == null)
            {
                return NotFound();
            }

            return Ok(cities);
        }

        [HttpPost("store-city/{itineraryId}")]
        public IActionResult StoreCityInItinerary(int itineraryId, [FromBody] string city)
        {
            var result = _itineraryService.StoreCityInItinerary(itineraryId, city);

            if (!result)
            {
                return NotFound(); // Handle case where itinerary is not found
            }

            return Ok(new { message = "City stored in itinerary successfully" });
        }

        // Other actions...

        // New action for storing the whole ItineraryDto
        [HttpPost("store-itinerary")]
        public IActionResult StoreItinerary([FromBody] ItineraryDto itineraryDto)
        {
            var createdItinerary = _itineraryService.CreateItinerary(itineraryDto);

            return CreatedAtAction(nameof(GetItineraryById), new { id = createdItinerary.Id }, createdItinerary);
        }

        [HttpPost("store-city-and-itinerary")]
        public IActionResult StoreCityAndItinerary([FromBody] CityAndItineraryDto data)
        {
            if (data == null)
            {
                return BadRequest("Invalid request data");
            }

            // Validate or process data as needed

            // Assuming you have a method in your service to create an itinerary
            var createdItinerary = _itineraryService.CreateItinerary(new ItineraryDto
            {
                City = data.City,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                // Add other properties as needed
            });

            // Assuming you have a method in your service to associate a city with an itinerary
            _itineraryService.StoreCityInItinerary(createdItinerary.Id, data.City);

            // You can return the created itinerary or any other response as needed
            return CreatedAtAction(nameof(GetItineraryById), new { id = createdItinerary.Id }, createdItinerary);
        }
    }
}
