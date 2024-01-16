using Microsoft.EntityFrameworkCore;
using System;
using TravelPlannerService.DbContextCreate;
using TravelPlannerService.Models;

namespace TravelPlannerService.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly AppDbContext _dbContext;

        public NoteRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Note> GetAll()
        {
            return _dbContext.Notes.ToList();
        }

        public Note GetById(int id)
        {
            return _dbContext.Notes.Find(id);
        }

        public void Add(Note note)
        {
            _dbContext.Notes.Add(note);
            _dbContext.SaveChanges();
        }

        public void Update(Note note)
        {
            _dbContext.Entry(note).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var note = _dbContext.Notes.Find(id);
            if (note != null)
            {
                _dbContext.Notes.Remove(note);
                _dbContext.SaveChanges();
            }
        }
    }
}
