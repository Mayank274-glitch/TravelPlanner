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

            // Configure relationships
            modelBuilder.Entity<Itinerary>()
                .HasMany(i => i.Places)
                .WithOne(p => p.Itinerary)
                .HasForeignKey(p => p.ItineraryId);

            // Add configurations for other entities in your database
        }
    }
}
