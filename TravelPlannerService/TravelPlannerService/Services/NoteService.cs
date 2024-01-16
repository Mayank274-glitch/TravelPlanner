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
    }
}
