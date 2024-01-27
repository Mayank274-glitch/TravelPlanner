using TravelPlannerService.Models;

namespace TravelPlannerService.Services
{
    public interface INoteService
    {
        IEnumerable<Note> GetAll();
        Note GetById(int id);
        Note CreateNoteByDate(DateTime date, Note note);
        IEnumerable<Note> GetNotesByDate(DateTime date);
        Note AddNoteByDate(Note note);
        Note GetNoteDetailsByDate(DateTime date, int id);
        Note UpdateNoteByDate(DateTime date, int id, Note note);
        void DeleteNoteByDate(DateTime date, int id);
        void Create(Note note);
        void Update(Note note);
        void Delete(int id);
    }
}
