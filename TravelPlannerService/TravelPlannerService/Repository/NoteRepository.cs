﻿// NoteRepository.cs
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Note> GetNotesByDate(DateTime date)
        {
            return _dbContext.Notes.Where(note => note.Date.Date == date.Date).ToList();
        }

        public void AddNoteByDate(Note note)
        {
            _dbContext.Notes.Add(note);
            _dbContext.SaveChanges();
        }

        public Note GetNoteDetailsByDate(DateTime date, int id)
        {
            return _dbContext.Notes.FirstOrDefault(note => note.Date.Date == date.Date && note.Id == id);
        }

        public void UpdateNoteByDate(Note note)
        {
            var existingNote = _dbContext.Notes.Find(note.Id);

            if (existingNote != null)
            {
                existingNote.Title = note.Title;
                existingNote.Content = note.Content;
                existingNote.Date = note.Date;

                _dbContext.SaveChanges();
            }
        }

        public void DeleteNoteByDate(DateTime date, int id)
        {
            var noteToRemove = _dbContext.Notes.FirstOrDefault(note => note.Date.Date == date.Date && note.Id == id);

            if (noteToRemove != null)
            {
                _dbContext.Notes.Remove(noteToRemove);
                _dbContext.SaveChanges();
            }
        }
    }
}
