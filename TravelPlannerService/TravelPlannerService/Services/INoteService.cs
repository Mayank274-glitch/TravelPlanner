using TravelPlannerService.Models;

namespace TravelPlannerService.Services
{
    public interface INoteService
    {
        IEnumerable<Note> GetAll();
        Note GetById(int id);
        void Create(Note note);
        void Update(Note note);
        void Delete(int id);
    }
}
