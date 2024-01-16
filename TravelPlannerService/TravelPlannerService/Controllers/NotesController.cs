using Microsoft.AspNetCore.Mvc;
using TravelPlannerService.Models;
using TravelPlannerService.Services;

namespace TravelPlannerService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public IEnumerable<Note> GetAll()
        {
            return _noteService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Note> GetById(int id)
        {
            var note = _noteService.GetById(id);

            if (note == null)
            {
                return NotFound();
            }

            return note;
        }

        [HttpPost]
        public ActionResult<Note> Create([FromBody] Note note)
        {
            _noteService.Create(note);
            return CreatedAtAction(nameof(GetById), new { id = note.Id }, note);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Note note)
        {
            if (id != note.Id)
            {
                return BadRequest();
            }

            _noteService.Update(note);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _noteService.Delete(id);
            return NoContent();
        }
    }
}
