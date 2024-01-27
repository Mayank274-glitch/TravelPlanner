using TravelPlannerService.Models;
using TravelPlannerService.Repository;

namespace TravelPlannerService.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public IEnumerable<Note> GetAll()
        {
            return _noteRepository.GetAll();
        }

        public Note GetById(int id)
        {
            return _noteRepository.GetById(id);
        }

        public void Create(Note note)
        {
            _noteRepository.Add(note);
        }

        public void Update(Note note)
        {
            _noteRepository.Update(note);
        }

        public void Delete(int id)
        {
            _noteRepository.Delete(id);
        }

        public IEnumerable<Note> GetNotesByDate(DateTime date)
        {
            return _noteRepository.GetNotesByDate(date);
        }

        public Note CreateNoteByDate(DateTime date, Note note)
        {
            note.Date = date;
            _noteRepository.Add(note);
            return note;
        }

        public Note AddNoteByDate(Note note)
        {
            _noteRepository.AddNoteByDate(note);
            return note;
        }

        public Note GetNoteDetailsByDate(DateTime date, int id)
        {
            return _noteRepository.GetNoteDetailsByDate(date, id);
        }

        public Note UpdateNoteByDate(DateTime date, int id, Note note)
        {
            var existingNote = _noteRepository.GetNoteDetailsByDate(date, id);

            if (existingNote != null)
            {
                existingNote.Title = note.Title;
                existingNote.Content = note.Content;
                existingNote.Date = note.Date;

                _noteRepository.Update(existingNote); // Assuming your repository method for update

                return existingNote; // Return the updated note
            }

            return null; // Indicate that the update failed
        }

        public void DeleteNoteByDate(DateTime date, int id)
        {
            _noteRepository.DeleteNoteByDate(date, id);
        }
    }
}
