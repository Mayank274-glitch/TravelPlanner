using Microsoft.AspNetCore.Mvc;
using TravelPlannerService.Models;
using TravelPlannerService.Services;

namespace TravelPlannerService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItineraryController : ControllerBase
    {
        private readonly IItineraryService _itineraryService;

        public ItineraryController(IItineraryService itineraryService)
        {
            _itineraryService = itineraryService;
        }

        [HttpGet]
        public IEnumerable<Itinerary> GetAll()
        {
            return _itineraryService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Itinerary> GetById(int id)
        {
            var itinerary = _itineraryService.GetById(id);

            if (itinerary == null)
            {
                return NotFound();
            }

            return itinerary;
        }

        [HttpPost]
        public ActionResult<Itinerary> Create([FromBody] Itinerary itinerary)
        {
            _itineraryService.Create(itinerary);
            return CreatedAtAction(nameof(GetById), new { id = itinerary.Id }, itinerary);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Itinerary itinerary)
        {
            if (id != itinerary.Id)
            {
                return BadRequest();
            }

            _itineraryService.Update(itinerary);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _itineraryService.Delete(id);
            return NoContent();
        }
    }
}
