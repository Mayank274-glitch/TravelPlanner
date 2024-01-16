using System.Collections.Generic;
using TravelPlannerService.Models;
using Microsoft.EntityFrameworkCore;

namespace TravelPlannerService.DbContextCreate
{
    public class AppDbContext : DbContext
    {
        public DbSet<Itinerary> Itineraries { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Note> Notes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Other configurations...

        // Initial data seed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Places
            modelBuilder.Entity<Place>().HasData(
                new Place { Id = 1, Name = "Place 1", Address = "Address 1", GooglePlaceId = "google_place_id_1" },
                new Place { Id = 2, Name = "Place 2", Address = "Address 2", GooglePlaceId = "google_place_id_2" }
            // Add more seeded places as needed
            );

            // Seed Notes
            modelBuilder.Entity<Note>().HasData(
                new Note { Id = 1, Title = "Note 1", Content = "Content 1", Date = DateTime.Now },
                new Note { Id = 2, Title = "Note 2", Content = "Content 2", Date = DateTime.Now }
            // Add more seeded notes as needed
            );

            // Seed Itineraries
            modelBuilder.Entity<Itinerary>().HasData(
                new Itinerary { Id = 1, Title = "Itinerary 1", Date = DateTime.Now },
                new Itinerary { Id = 2, Title = "Itinerary 2", Date = DateTime.Now.AddDays(1) }
            // Add more seeded itineraries as needed
            );

            // Add configurations for other entities in your database
        }
    }
}
