using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MediaDatabaseCreator.Model
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) {}
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Franchise> Franchises { get; set; }

        
    }
}
