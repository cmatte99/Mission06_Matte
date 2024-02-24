using Microsoft.EntityFrameworkCore;

namespace Mission06_Matte.Models
{
    // Database context for handling movie and category data
    public class MovieEntriesContext : DbContext
    {
        // Constructor to initialize the context with options
        public MovieEntriesContext(DbContextOptions<MovieEntriesContext> options) : base(options)
        {
        }

        // DbSet for accessing movie data in the database
        public DbSet<Movies> Movies { get; set; }

        // DbSet for accessing category data in the database
        public DbSet<Category> Categories { get; set; }

        // Method to configure model relationships and seed initial data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed initial category data
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "RomCom" },
                new Category { CategoryId = 2, CategoryName = "Horror" },
                new Category { CategoryId = 3, CategoryName = "Suspense" }
            );
        }
    }
}
