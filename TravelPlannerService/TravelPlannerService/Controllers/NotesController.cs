// NotesController.cs
using Microsoft.AspNetCore.Mvc;
using TravelPlannerService.Models;
using TravelPlannerService.Services;
using System;
using System.Collections.Generic;

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

        [HttpGet("by-date/{date}")]
        public IActionResult GetNotesByDate(DateTime date)
        {
            var notes = _noteService.GetNotesByDate(date);
            return Ok(notes);
        }

        [HttpPost("by-date")]
        public IActionResult CreateNoteByDate([FromBody] Note note)
        {
            var createdNote = _noteService.AddNoteByDate(note);

            if (createdNote == null)
            {
                return BadRequest("Failed to add note.");
            }

            return CreatedAtAction(nameof(GetNotesByDate), new { date = createdNote.Date }, createdNote);
        }

        [HttpGet("by-date/{date}/{id}")]
        public IActionResult GetNoteDetailsByDate(DateTime date, int id)
        {
            var note = _noteService.GetNoteDetailsByDate(date, id);

            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        [HttpPut("by-date/{date}/{id}")]
        public IActionResult UpdateNoteByDate(DateTime date, int id, [FromBody] Note note)
        {
            var updatedNote = _noteService.UpdateNoteByDate(date, id, note);

            if (updatedNote == null)
            {
                return NotFound();
            }

            return Ok(updatedNote);
        }

        [HttpDelete("by-date/{date}/{id}")]
        public IActionResult DeleteNoteByDate(DateTime date, int id)
        {
            _noteService.DeleteNoteByDate(date, id);
            return NoContent();
        }
    }
}
