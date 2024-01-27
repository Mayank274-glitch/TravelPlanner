using TravelPlannerService.Models;

namespace TravelPlannerService.Repository
{
    public interface INoteRepository
    {
        IEnumerable<Note> GetAll();
        Note GetById(int id);
        IEnumerable<Note> GetNotesByDate(DateTime date);
        void AddNoteByDate(Note note);
        Note GetNoteDetailsByDate(DateTime date, int id);
        void UpdateNoteByDate(Note note);
        void DeleteNoteByDate(DateTime date, int id);
        void Add(Note note);
        void Update(Note note);
        void Delete(int id);
    }
}
