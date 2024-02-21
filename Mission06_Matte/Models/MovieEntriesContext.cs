using Microsoft.EntityFrameworkCore;

namespace Mission06_Matte.Models
{
    public class MovieEntriesContext : DbContext
    {
        public MovieEntriesContext(DbContextOptions<MovieEntriesContext> options) : base (options) 
        { 
        }
        public DbSet<Application> Applications { get; set; }
    }

}
