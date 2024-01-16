using TravelPlannerService.Models;

namespace TravelPlannerService.Repository
{
    public interface INoteRepository
    {
        IEnumerable<Note> GetAll();
        Note GetById(int id);
        void Add(Note note);
        void Update(Note note);
        void Delete(int id);
    }
}
